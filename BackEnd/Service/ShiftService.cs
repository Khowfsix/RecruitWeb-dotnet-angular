using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IMapper _mapper;

        public ShiftService(IShiftRepository shiftRepository, IMapper mapper)
        {
            _shiftRepository = shiftRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShiftModel>> GetAllShifts(int? request)
        {
            var entities = await _shiftRepository.GetAllShifts(request);
            if (entities != null)
            {
                List<ShiftModel> models = new List<ShiftModel>();
                foreach (var item in entities)
                {
                    models.Add(_mapper.Map<ShiftModel>(item));
                }
                return models;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<ShiftModel> SaveShift(ShiftModel request)
        {
            var entity = _mapper.Map<Shift>(request);
            var response = await _shiftRepository.SaveShift(entity);
            return _mapper.Map<ShiftModel>(response);
        }

        public async Task<bool> UpdateShift(ShiftModel request, Guid requestId)
        {
            var entity = _mapper.Map<Shift>(request);
            return await _shiftRepository.UpdateShift(entity, requestId);
        }

        public async Task<bool> DeleteShift(Guid requestId)
        {
            return await _shiftRepository.DeleteShift(requestId);
        }
    }
}