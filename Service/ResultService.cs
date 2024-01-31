using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _reportRepository;
        private readonly IMapper _mapper;

        public ResultService(IResultRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<ResultModel> SaveResult(ResultModel reportModel)
        {
            var entity = _mapper.Map<Result>(reportModel);
            var response = await _reportRepository.SaveResult(entity);
            return _mapper.Map<ResultModel>(response);
        }

        public async Task<bool> DeleteResult(Guid reportModelId)
        {
            return await _reportRepository.DeleteResult(reportModelId);
        }

        public async Task<IEnumerable<ResultModel>> GetAllResult()
        {
            var entities = await _reportRepository.GetAllResult();
            List<ResultModel> models = new List<ResultModel>();
            foreach (var item in entities)
            {
                models.Add(_mapper.Map<ResultModel>(item));
            }
            return models;
        }

        public async Task<bool> UpdateResult(ResultModel reportModel, Guid reportModelId)
        {
            var entity = _mapper.Map<Result>(reportModel);
            return await _reportRepository.UpdateResult(entity, reportModelId);
        }
    }
}