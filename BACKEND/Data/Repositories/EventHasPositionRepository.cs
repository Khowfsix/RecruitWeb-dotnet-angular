using Data.CustomModel.Interviewer;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repositories;

public class EventHasPositionRepository : Repository<EventHasPosition>, IEventHasPositionRepository
{
    private readonly IUnitOfWork _uow;

    public EventHasPositionRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
    {
        _uow = uow;
    }
    public async Task<EventHasPosition> SaveEventHasPosition(EventHasPosition request)
    {
        request.EventHasPositionId = Guid.NewGuid();
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

    public async Task<bool> DeleteEventHasPosition(Guid requestId)
    {
        try
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.EventHasPositionId == requestId);
            if (entity is null )
            {
                return await Task.FromResult(false);
            }

            Entities.Remove(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            throw;
        }
    }
}