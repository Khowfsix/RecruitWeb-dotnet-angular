using AutoMapper;
using Data.CustomModel.Interviewer;
using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class InterviewRepository : Repository<Interview>, IInterviewRepository
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public InterviewRepository(RecruitmentWebContext context, IUnitOfWork uow, IMapper mapper) : base(context)
    {
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<IEnumerable<Interview>> GetInterviewsByCompanyId(Guid companyId, InterviewFilter interviewFilter, string sortString)
    {
        var query = Entities
            .Where(e => e.Application.Position.CompanyId.Equals(companyId))
            .Include(i => i.Recruiter)
                .ThenInclude(e => e.User)
            .Include(i => i.Interviewer)
                .ThenInclude(e => e.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position)
            .Include(i => i.Application)
                .ThenInclude(a => a.Cv)
                    .ThenInclude(c => c.Candidate)
                        .ThenInclude(e => e.User)
            .Include(i => i.Rounds)
                .ThenInclude(r => r.Question)
                .AsNoTracking();

        if (!string.IsNullOrEmpty(sortString))
        {
            switch (sortString)
            {
                case "MeetingDate_DESC":
                    query = query.OrderByDescending(e => e.MeetingDate);
                    break;
                case "MeetingDate_ASC":
                    query = query.OrderBy(e => e.MeetingDate);
                    break;
                case "CandidateName_DESC":
                    query = query.OrderByDescending(e => e.Application.Cv.Candidate.User!.UserName);
                    break;
                case "CandidateName_ASC":
                    query = query.OrderBy(e => e.Application.Cv.Candidate.User!.UserName);
                    break;
                case "RecruiterName_DESC":
                    query = query.OrderByDescending(e => e.Recruiter.User.UserName);
                    break;
                case "RecruiterName_ASC":
                    query = query.OrderBy(e => e.Recruiter.User.UserName);
                    break;
                case "InterviewerName_DESC":
                    query = query.OrderByDescending(e => e.Interviewer.User.UserName);
                    break;
                case "InterviewerName_ASC":
                    query = query.OrderBy(e => e.Interviewer.User.UserName);
                    break;
            }
        }
      

        if (!string.IsNullOrEmpty(interviewFilter.Search))
        {
            query = query
                .Where(e =>
                e.Recruiter.User.UserName.ToLower().Contains(interviewFilter.Search.ToLower())
                || e.Interviewer.User.UserName.ToLower().Contains(interviewFilter.Search.ToLower()) 
                || e.Application.Cv.Candidate.User!.UserName.ToLower().Contains(interviewFilter.Search.ToLower())
                );
        }

        if (interviewFilter.CandidateStatus.HasValue)
        {
            query = query.Where(e => e.Candidate_Status.Equals(interviewFilter.CandidateStatus.Value));
        }

        if (interviewFilter.CompanyStatus.HasValue)
        {
            query = query.Where(e => e.Company_Status.Equals(interviewFilter.CompanyStatus.Value));
        }

        if (interviewFilter.FromTime != null && interviewFilter.ToTime != null)
        {
            TimeSpan fromTimeSpan = TimeSpan.Parse(interviewFilter.FromTime);
            TimeSpan toTimeSpan = TimeSpan.Parse(interviewFilter.ToTime);
            query = query.Where(e => fromTimeSpan <= e.StartTime && toTimeSpan <= e.EndTime);
        }

        if (interviewFilter.FromDate.HasValue && interviewFilter.ToDate.HasValue)
        {
            query = query.Where(e => interviewFilter.FromDate.Value <= e.MeetingDate && e.MeetingDate <= interviewFilter.ToDate.Value);
        }

        var result = await query
            .ToListAsync();

        return result;
    }

    public async Task<IEnumerable<Interview>> GetAllInterview()
    {
        var listDatas = await Entities
            //.Include(i => i.Itrsinterview)
            //    .ThenInclude(t => t.Room)
            //.Include(i => i.Itrsinterview)
            //    .ThenInclude(t => t.Shift)
            .Include(i => i.Recruiter.User)
            .Include(i => i.Interviewer.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position.Company)
            .Include(i => i.Application)
                .ThenInclude(a => a.Cv)
                    .ThenInclude(c => c.Candidate.User)
            .Include(i => i.Rounds)
                .ThenInclude(r => r.Question)
            .ToListAsync();

        return listDatas;
    }

    public async Task<Interview?> GetInterviewById(Guid id)
    {
        var item = await Entities
            .Where(i => i.InterviewId.Equals(id))
            //.Include(i => i.Itrsinterview)
            //    .ThenInclude(t => t!.Room)
            //.Include(i => i.Itrsinterview)
            //    .ThenInclude(t => t!.Shift)
            .Include(i => i.Recruiter.User)
            .Include(i => i.Interviewer.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position.Company)
            .Include(i => i.Application)
                .ThenInclude(a => a.Cv)
                    .ThenInclude(c => c.Candidate.User)
            .Include(i => i.Rounds)
                .ThenInclude(r => r.Question)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return item is not null ? item : null;
    }

    public async Task<Interview?> GetInterviewById_NoInclude(Guid id)
    {
        var item = await Entities
            .Where(i => i.InterviewId.Equals(id))
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return item is not null ? item : null;
    }

    public async Task<Interview?> SaveInterview(Interview request)
    {
        request.InterviewId = Guid.NewGuid();

        Entities.Add(request);
        try { _uow.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }

        return await Task.FromResult(request);
    }

    public async Task<bool> UpdateInterview(Interview request, Guid requestId)
    {
        try
        {
            var foundInterview = await Entities.FirstOrDefaultAsync(e => e.InterviewId == requestId);
            if (foundInterview != null)
            {
                _mapper.Map(request, foundInterview);
                Entities.Update(foundInterview);
                _uow.SaveChanges();
                return true;
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteInterview(Guid requestId)
    {
        try
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.InterviewId == requestId);
            if (entity is null or { IsDeleted: true })
            {
                return await Task.FromResult(false);
            }

            entity.IsDeleted = true;
            Entities.Update(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Interview>> GetInterviewOfInterviewer(Guid id)
    {
        var listDatas = await Entities.Where(i => i.InterviewerId.Equals(id))
            .Include(i => i.Recruiter.User)
            .Include(i => i.Interviewer.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position.Company)
            .Include(i => i.Application)
                .ThenInclude(a => a.Cv)
                    .ThenInclude(c => c.Candidate.User)
            .Include(i => i.Rounds)
                .ThenInclude(r => r.Question)
            .OrderByDescending(e => e.MeetingDate)
            .AsNoTracking()
            .ToListAsync();

        return listDatas;
    }

    public async Task<IEnumerable<Interview>> InterviewReport(DateTime fromDate, DateTime toDate)
    {
        var interview = await Entities
            .Include(x => x.Application)
                .ThenInclude(x => x.Cv)
                .ThenInclude(x => x.Candidate)
            .Include(x => x.Recruiter)
            .Include(x => x.Interviewer)
            .Include(x => x.Rounds)
            .Where(x => fromDate <= x.Application.CreatedTime && x.Application.CreatedTime <= toDate)
            .ToListAsync();

        return interview;
    }
}