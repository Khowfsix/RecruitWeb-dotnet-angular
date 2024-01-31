using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteDepartment(Guid requestId)
        {
            return await _departmentRepository.DeleteDepartment(requestId);
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartment(string? request)
        {
            var data = await _departmentRepository.GetAllDepartment(request);
            if (!data.IsNullOrEmpty())
            {
                List<DepartmentModel> result = _mapper.Map<List<DepartmentModel>>(data);
                return result;
            }
            return null!;
        }

        public async Task<DepartmentModel> SaveDepartment(DepartmentModel request)
        {
            var data = _mapper.Map<Department>(request);
            var response = await _departmentRepository.SaveDepartment(data);
            return _mapper.Map<DepartmentModel>(response);
        }

        public async Task<bool> UpdateDepartment(DepartmentModel request, Guid requestId)
        {
            var data = _mapper.Map<Department>(request);
            return await _departmentRepository.UpdateDepartment(data, requestId);
        }
    }
}