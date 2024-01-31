﻿using AutoMapper;
using Data.Interfaces;
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
            List<DepartmentModel> result = new List<DepartmentModel>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<DepartmentModel>(item);
                    result.Add(obj);
                }
                return result;
            }
            return null!;
        }

        public async Task<DepartmentModel> SaveDepartment(DepartmentModel request)
        {
            var data = _mapper.Map<DepartmentModel>(request);
            var response = await _departmentRepository.SaveDepartment(data);
            return _mapper.Map<DepartmentModel>(response);
        }

        public async Task<bool> UpdateDepartment(DepartmentModel request, Guid requestId)
        {
            var data = _mapper.Map<DepartmentModel>(request);
            return await _departmentRepository.UpdateDepartment(data, requestId);
        }
    }
}