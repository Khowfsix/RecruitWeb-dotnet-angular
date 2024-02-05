using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ItrsinterviewRepository : Repository<Itrsinterview>, IItrsinterviewRepository
{
    private readonly IUnitOfWork _uow;

    public ItrsinterviewRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Itrsinterview>> GetAllItrsinterview()
    {
        var listDatas = await Entities
            .Include(i => i.Room)
            .Include(i => i.Shift)
            .ToListAsync();

        return listDatas;
    }

    public async Task<IEnumerable<Itrsinterview>> GetAllItrsinterview_NoInclude()
    {
        var listData = await Entities
            .AsNoTracking()
            .ToListAsync();

        return listData;
    }

    public async Task<Itrsinterview?> GetItrsinterviewById(Guid id)
    {
        var item = await Entities
            .Include(i => i.Room)
            .Include(i => i.Shift)
            .Where(i => i.ItrsinterviewId.Equals(id))
            .FirstOrDefaultAsync();

        return item is not null ? item : null;
    }

    public async Task<Itrsinterview?> SaveItrsinterview(Itrsinterview request, Guid interviewerId)
    {
        request.ItrsinterviewId = Guid.NewGuid();

        _uow.BeginTransaction();

        Entities.Add(request);
        try
        {
            _uow.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            _uow.RollbackTransaction();
            _uow.Dispose();

            return null!;
        }
        _uow.CommitTransaction();

        return await Task.FromResult(request);
    }

    public async Task<bool> UpdateItrsinterview(Itrsinterview request, Guid requestId)
    {
        request.ItrsinterviewId = requestId;
        Entities.Update(request);
        try { _uow.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItrsinterview(Guid requestId)
    {
        try
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.ItrsinterviewId == requestId);
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            Entities.Remove(entity);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return await Task.FromResult(false);
        }
    }
}