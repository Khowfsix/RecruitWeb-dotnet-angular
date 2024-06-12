using Data.CustomModel.Event;
using Data.CustomModel.Interviewer;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    public async Task<IEnumerable<Event>> GetAllEventByRecruiterId(Guid recruiterId, EventFilter eventFilter, string sortString)
    {
        var query = Entities
            .Where(iDel => iDel.IsDeleted == false && iDel.RecruiterId == recruiterId)
            .Include(e => e.Recruiter.User)
            .Include(e => e.EventHasPositions).ThenInclude(e => e.Position)
            .AsNoTracking();
       
        if (!string.IsNullOrEmpty(sortString)) {
            var sort = new Sort<Event>(sortString);
            query = sort.getSort(query);
        }

        if (!string.IsNullOrEmpty(eventFilter.Search))
        {
            var lowewedSearch = eventFilter.Search.ToLower();
            query = query
            .Where(e =>
                e.EventName.ToLower().Contains(lowewedSearch)
                || e.Description.ToLower().Contains(lowewedSearch)
                || e.Place.ToLower().Contains(lowewedSearch)
            );
        }

        if (eventFilter.FromDate.HasValue && eventFilter.ToDate.HasValue)
        {
            query = query.Where(o => !((o.StartDateTime.Date > eventFilter.ToDate.Value.Date) || (o.EndDateTime.Date < eventFilter.FromDate.Value.Date)));
        }

        if (eventFilter.FromMaxParticipants.HasValue && eventFilter.ToMaxParticipants.HasValue)
        {
            query = query.Where(o => o.MaxParticipants >= eventFilter.FromMaxParticipants.Value);
            query = query.Where(o => o.MaxParticipants <= eventFilter.ToMaxParticipants.Value);
        }

        var result = await query.ToListAsync();

        return result;
    }

    public async Task<Event> GetEventById(Guid id)
    {
        var item = await Entities.Where(e => e.EventId == id)
            .Include(e => e.EventHasPositions)
                .ThenInclude(e => e.Position)
            .Include(e => e.Recruiter.User)
            .Include(e => e.Recruiter.Company)
            .AsNoTracking()
            .FirstAsync();
        if (item is null) 
            return null!;
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
            var entity = await Entities.FindAsync(requestId);
            if (entity is null)
            {
                return await Task.FromResult(false);
            }

            entity.EventName = request.EventName;
            entity.ImageURL = request.ImageURL;
            entity.RecruiterId = request.RecruiterId;
            entity.Description = request.Description;
            entity.Place = request.Place;
            entity.StartDateTime = request.StartDateTime;
            entity.EndDateTime = request.EndDateTime;
            entity.MaxParticipants = request.MaxParticipants;

            Entities.Update(entity);

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