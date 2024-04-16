using Data.CustomModel.Interviewer;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class InterviewerRepository : Repository<Interviewer>, IInterviewerRepository
{
    private readonly IUnitOfWork _uow;

    public InterviewerRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Interviewer>> GetInterviewersInCompany(Guid companyId, InterviewerFilter interviewerFilter, string sortString)
    {
        var query = Entities.Where(o => o.CompanyId.Equals(companyId));

        if (sortString != null)
        {
            switch (sortString)
            {
                case "FullName_ASC":
                    query = query.Include(e => e.User).OrderBy(e => e.User.FullName);
                    break;
                case "FullName_DESC":
                    query = query.Include(e => e.User).OrderByDescending(e => e.User.FullName);
                    break;
            }
        }

        if (!string.IsNullOrEmpty(interviewerFilter.Search))
        {
            query = query.Where(o => o.User.FullName!.ToLower().Contains(interviewerFilter.Search.ToLower()));
        }
        //if (interviewerFilter.FromTime != null && interviewerFilter.ToTime != null)
        //{
        //    TimeSpan fromTimeSpan = TimeSpan.Parse(interviewerFilter.FromTime);
        //    TimeSpan toTimeSpan = TimeSpan.Parse(interviewerFilter.ToTime);
        //    query = query.Include(o => o.Interviews).ThenInclude(o => o.Itrsinterview);
        //    query = query.Where(o =>
        //                o.Interviews != null &&
        //                o.Interviews.Any(x => x.Itrsinterview != null
        //                    && x.Itrsinterview.DateInterview.TimeOfDay <= toTimeSpan
        //                    && x.Itrsinterview.DateInterview.TimeOfDay >= fromTimeSpan)
        //                );
        //}

        if (interviewerFilter.FromDate.HasValue && interviewerFilter.ToDate.HasValue)
        {
            query = query.Include(o => o.Interviews).ThenInclude(o => o.Itrsinterview);
            
            if (interviewerFilter.IsFreeTime!.Value)
            {
                query = query.Where(o =>
                    o.Interviews == null ||
                    !o.Interviews.Any(x => x.Itrsinterview != null
                        && x.Itrsinterview.DateInterview <= interviewerFilter.ToDate.Value
                        && x.Itrsinterview.DateInterview >= interviewerFilter.FromDate.Value)
                    );
            }
            if (interviewerFilter.IsBusyTime!.Value)
            {
                query = query.Where(o =>
                    o.Interviews != null &&
                    o.Interviews.Any(x => x.Itrsinterview != null
                        && x.Itrsinterview.DateInterview <= interviewerFilter.ToDate.Value
                        && x.Itrsinterview.DateInterview >= interviewerFilter.FromDate.Value)
                    );
            } 
           
        }
        else {
            if (interviewerFilter.IsFreeTime!.Value != interviewerFilter.IsBusyTime!.Value)
            {
                if (interviewerFilter.IsFreeTime.Value)
                    query = query.Include(e => e.Interviews).Where(o => o.Interviews.Count() == 0);
                else
                    query = query.Include(e => e.Interviews).Where(o => o.Interviews.Count() != 0);
            }
        }

        var result = await query
                .ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Interviewer>> GetAllInterviewer()
    {
        var listDatas = await Entities.Include(x => x.User).ToListAsync();
        return listDatas;
    }

    public async Task<Interviewer?> GetInterviewerById(Guid id)
    {
        var item = await Entities.Include(x => x.User).Where(x => x.InterviewerId == id).FirstOrDefaultAsync();
        if (item is null or { IsDeleted: true }) return null;
        return item;
    }

    public async Task<Interviewer> SaveInterviewer(Interviewer request)
    {
        request.InterviewerId = Guid.NewGuid();

        Entities.Add(request);
        try { _uow.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //return await Task.FromResult(false);
            return null!;
        }

        return await Task.FromResult(request);
    }

    public async Task<bool> UpdateInterviewer(Interviewer request, Guid requestId)
    {
        request.InterviewerId = requestId;
        Entities.Update(request);
        try { _uow.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteInterviewer(Guid requestId)
    {
        try
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.InterviewerId == requestId);
            if (entity is null or { IsDeleted: true })
            {
                return await Task.FromResult(false);
            }
            entity.IsDeleted = true;
            Entities.Update(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Interviewer>> GetInterviewersInCompany(Guid deparmentId)
    {
        var listDatas = await Entities.Include(x => x.User)
            .Where(i => i.CompanyId.Equals(deparmentId))
            .Where(iDel => iDel.IsDeleted == false)
            .ToListAsync();

        return listDatas;
    }
}