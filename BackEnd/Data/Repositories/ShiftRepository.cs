using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        private readonly IUnitOfWork _uow;

        public ShiftRepository(RecruitmentWebContext dbContext,
            IUnitOfWork uow) : base(dbContext)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Shift>> GetAllShifts(int? request)
        {
            if (request == null)
            {
                var datas = await Entities.Take(10).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await Entities.Where(s => s.ShiftTimeStart == request || s.ShiftTimeEnd == request)
                                          .Take(10).ToListAsync();
                return datas;
            }
        }

        public async Task<Shift> SaveShift(Shift request)
        {
            request.ShiftId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateShift(Shift request, Guid requestId)
        {
            request.ShiftId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteShift(Guid requestId)
        {
            var data = GetById(requestId);
            try
            {
                if (data != null)
                {
                    Entities.Remove(data);
                    _uow.SaveChanges();

                    return await Task.FromResult(true);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
                //throw new ArgumentNullException(nameof(data));
            }
            return await Task.FromResult(false);
        }
    }
}