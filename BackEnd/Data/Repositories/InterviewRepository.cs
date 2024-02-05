using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class InterviewRepository : Repository<Interview>, IInterviewRepository
{
    private readonly IUnitOfWork _uow;

    public InterviewRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Interview>> GetAllInterview()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var listDatas = await Entities
            .Include(i => i.Itrsinterview)
                .ThenInclude(t => t.Room)
            .Include(i => i.Itrsinterview)
                .ThenInclude(t => t.Shift)
            .Include(i => i.Recruiter.User)
            .Include(i => i.Interviewer.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position.Department)
            .Include(i => i.Application)
                .ThenInclude(a => a.Cv)
                    .ThenInclude(c => c.Candidate.User)
            .Include(i => i.Rounds)
                .ThenInclude(r => r.Question)
            .ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return listDatas;
    }

    public async Task<Interview?> GetInterviewById(Guid id)
    {
        var item = await Entities
            .Where(i => i.InterviewId.Equals(id))
            .Include(i => i.Itrsinterview)
                .ThenInclude(t => t!.Room)
            .Include(i => i.Itrsinterview)
                .ThenInclude(t => t!.Shift)
            .Include(i => i.Recruiter.User)
            .Include(i => i.Interviewer.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position.Department)
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
            request.InterviewId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();
            return await Task.FromResult(true);
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
            .Where(i => i.InterviewId.Equals(id))
            .Include(i => i.Itrsinterview)
                .ThenInclude(t => t!.Room)
            .Include(i => i.Itrsinterview)
                .ThenInclude(t => t!.Shift)
            .Include(i => i.Recruiter.User)
            .Include(i => i.Interviewer.User)
            .Include(i => i.Application)
                .ThenInclude(a => a.Position.Department)
            .Include(i => i.Application)
                .ThenInclude(a => a.Cv)
                    .ThenInclude(c => c.Candidate.User)
            .Include(i => i.Rounds)
                .ThenInclude(r => r.Question)
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
            .Include(x => x.Result)
            .Include(x => x.Rounds)
            .Where(x => fromDate <= x.Application.DateTime && x.Application.DateTime <= toDate)
            .ToListAsync();

        return interview;
    }
}