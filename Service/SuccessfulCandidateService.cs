using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Data.ViewModels.SuccessfulCadidate;
using Service.Interfaces;

namespace Service
{
    public class SuccessfulCandidateService : ISuccessfulCandidateService
    {
        private readonly ISuccessfulCadidateRepository _successfulCadidateRepository;
        private readonly IMapper _mapper;

        public SuccessfulCandidateService(ISuccessfulCadidateRepository successfulCadidateRepository, IMapper mapper)
        {
            _successfulCadidateRepository = successfulCadidateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SuccessfulCadidateViewModel>> GetAllSuccessfulCadidates(string? request)
        {
            var modelDatas = await _successfulCadidateRepository.GetAllSuccessfulCadidates(request);
            if (modelDatas != null)
            {
                List<SuccessfulCadidateViewModel> list = new List<SuccessfulCadidateViewModel>();
                foreach (var item in modelDatas)
                {
                    list.Add(_mapper.Map<SuccessfulCadidateViewModel>(item));
                }
                return list;
            }
            return null;
        }

        public async Task<SuccessfulCadidateViewModel> SaveSuccessfulCadidate(SuccessfulCadidateAddModel request)
        {
            var data = _mapper.Map<SuccessfulCadidateModel>(request);
            var response = await _successfulCadidateRepository.SaveSuccessfulCadidate(data);
            return _mapper.Map<SuccessfulCadidateViewModel>(response);
        }

        public async Task<bool> UpdateSuccessfulCadidate(SuccessfulCadidateUpdateModel request, Guid requestId)
        {
            var data = _mapper.Map<SuccessfulCadidateModel>(request);
            return await _successfulCadidateRepository.UpdateSuccessfulCadidate(data, requestId);
        }

        public async Task<bool> DeleteSuccessfulCadidate(Guid requestId)
        {
            return await _successfulCadidateRepository.DeleteSuccessfulCadidate(requestId);
        }
    }
}