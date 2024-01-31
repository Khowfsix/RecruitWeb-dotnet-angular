using Service.Models;

namespace Service.Interfaces
{
    public interface IShiftService
    {
        Task<IEnumerable<ShiftModel>> GetAllShifts(int? request);

        Task<ShiftModel> SaveShift(ShiftModel request);

        Task<bool> UpdateShift(ShiftModel request, Guid requestId);

        Task<bool> DeleteShift(Guid requestId);
    }
}