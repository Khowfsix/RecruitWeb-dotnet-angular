using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    private readonly IUnitOfWork _uow;

    public EventRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Event>> GetAllEvent()
    {
        var listDatas = await Entities
            .Where(iDel => iDel.IsDeleted == false)
            .ToListAsync();

        return listDatas;
    }

    public async Task<Event> GetEventById(Guid id)
    {
        var item = await Entities.FindAsync(id);
        if (item is null or { IsDeleted: true }) return null!;
        return item;
    }

    public async Task<Event> SaveEvent(Event request)
    {
        request.EventId = Guid.NewGuid();
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

    public async Task<bool> UpdateEvent(Event request, Guid requestId)
    {
        try
        {
            var entity = await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.EventId == requestId);
            if (entity is null or { IsDeleted: true })
            {
                return await Task.FromResult(false);
            }

            request.EventId = requestId;
            Entities.Update(request);

            _uow.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteEvent(Guid requestId)
    {
        try
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.EventId == requestId);
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
}