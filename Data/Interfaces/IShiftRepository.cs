using Data.Entities;

namespace Data.Interfaces
{
    public interface IShiftRepository : IRepository<Shift>
    {
        Task<IEnumerable<Shift>> GetAllShifts(int? request);

        Task<Shift> SaveShift(Shift request);

        Task<bool> UpdateShift(Shift request, Guid requestId);

        Task<bool> DeleteShift(Guid requestId);
    }
}