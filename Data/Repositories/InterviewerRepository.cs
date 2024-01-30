using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class InterviewerRepository : Repository<Interviewer>, IInterviewerRepository
{
    private readonly IUnitOfWork _uow;

    public InterviewerRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
    {
        _uow = uow;
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

    public async Task<IEnumerable<Interviewer>> GetInterviewersInDepartment(Guid deparmentId)
    {
        var listDatas = await Entities.Include(x => x.User)
            .Where(i => i.DepartmentId.Equals(deparmentId))
            .Where(iDel => iDel.IsDeleted == false)
            .ToListAsync();

        return listDatas;
    }
}