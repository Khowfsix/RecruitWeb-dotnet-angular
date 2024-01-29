using Data.Entities;

using Api.ViewModels.Shift;
using System.Data.SqlTypes;

namespace Data.Interfaces
{
    public interface IShiftRepository : IRepository<Shift>
    {
        Task<IEnumerable<ShiftModel>> GetAllShifts(int? request);
        Task<ShiftModel> SaveShift(ShiftModel request);
        Task<bool> UpdateShift(ShiftModel request, Guid requestId);
        Task<bool> DeleteShift(Guid requestId);
    }
}