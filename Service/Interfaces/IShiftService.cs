
using Api.ViewModels.Shift;

namespace Service.Interfaces
{
    public interface IShiftService
    {
        Task<IEnumerable<ShiftViewModel>> GetAllShifts(int? request);

        Task<ShiftViewModel> SaveShift(ShiftAddModel request);

        Task<bool> UpdateShift(ShiftUpdateModel request, Guid requestId);

        Task<bool> DeleteShift(Guid requestId);
    }
}