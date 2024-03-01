using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class RecruiterRepository : Repository<Recruiter>, IRecruiterRepository
{
    private readonly IUnitOfWork _uow;

    public RecruiterRepository(RecruitmentWebContext context,
        IUnitOfWork uow) : base(context)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Recruiter>> GetAllRecruiter()
    {
        var listData = await Entities.Include(x => x.User).Include(x => x.Company).ToListAsync();
        return listData;
    }

    public async Task<Recruiter?> GetRecruiterById(Guid id)
    {
        var item = await Entities.Include(x => x.User).Include(x => x.Company).Where(r => r.RecruiterId == id)
            .FirstOrDefaultAsync();
        if (item is null) return null;
        return item;
    }

    public async Task<Recruiter> GetRecruiterByUserId(string id)
    {
        var item = await Entities
            .Include(r => r.User)
            .Include(r => r.Company)
            .Where(r => r.UserId.Equals(id))
            .FirstOrDefaultAsync();

        return item!;
    }

    public async Task<Recruiter?> SaveRecruiter(Recruiter entity)
    {
        entity.RecruiterId = Guid.NewGuid();

        Entities.Add(entity);
        _uow.SaveChanges();
        try { _uow.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }
        return await Task.FromResult(entity);
    }

    public async Task<bool> UpdateRecruiter(Recruiter request, Guid requestId)
    {
        request.RecruiterId = requestId;

        Entities.Update(request);
        try { _uow.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteRecruiter(Guid requestId)
    {
        var entity = await Entities.FirstOrDefaultAsync(x => x.RecruiterId == requestId);
        if (entity is null or { IsDeleted: true })
        {
            return await Task.FromResult(false);
        }
        entity.IsDeleted = true;
        Entities.Update(entity);
        _uow.SaveChanges();

        //try
        //{
        //    Entities.Remove(entity);
        //    _uow.SaveChanges();
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
        return await Task.FromResult(true);
    }
}