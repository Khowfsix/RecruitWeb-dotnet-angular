using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly IUnitOfWork _uow;

        public RoomRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<Room> SaveRoom(Room request)
        {
            request.RoomId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateRoom(Room request, Guid requestId)
        {
            request.RoomId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRoom(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.RoomId == requestId);
            if (entity is null or { IsDeleted: true })
            {
                return await Task.FromResult(false);
            }
            entity.IsDeleted = true;
            Entities.Update(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
        public async Task<Room> GetRoomById(Guid id)
        {
            var entity = await Entities.FindAsync(id);
            return entity;
        }
    }
}