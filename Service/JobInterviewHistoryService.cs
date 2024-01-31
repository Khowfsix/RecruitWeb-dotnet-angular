using AutoMapper;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class JobInterviewHistoryService : IJobInterviewHistoryService
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly ICandidateRepository _candidateRepository;

        private readonly IApplicationRepository _applicationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly ICvRepository _cvRepository;
        private readonly IInterviewerRepository _interviewerRepository;
        private readonly IItrsinterviewRepository _itrsinterviewRepository;
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;

        public JobInterviewHistoryService(IApplicationRepository applicationRepository, IRoomRepository roomRepository,
                                          IPositionRepository positionRepository, ICvRepository cvRepository,
                                          IInterviewerRepository interviewerRepository,
                                          IItrsinterviewRepository itrsinterviewRepository,
                                          //ICandidateRepository candidateRepository,
                                          IInterviewRepository interviewRepository,
                                          IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _roomRepository = roomRepository;
            _positionRepository = positionRepository;
            _cvRepository = cvRepository;
            _interviewerRepository = interviewerRepository;
            _itrsinterviewRepository = itrsinterviewRepository;
            //_candidateRepository = candidateRepository;
            _interviewRepository = interviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ApplicationModel>> GetApplicationHistory(Guid candidateId)

        {
            // var currentUserId =
            //    ClaimsPrincipal.Current.FindFirst(i => i.Type == ClaimTypes.Name).Value;

            // var currentCandidateId = _candidateRepository.GetCandidateByUserId(currentUserId);

            var cvList = await _cvRepository.GetCvsByCandidateId(candidateId);

            List<ApplicationModel> result = new();
            foreach (var cv in cvList)
            {
                var applicationHistory = await _applicationRepository.GetApplicationHistory(cv.Cvid);
                result = _mapper.Map<List<ApplicationModel>>(applicationHistory);
            }
            return result.AsEnumerable().OrderByDescending(application => application.DateTime).ToList();
        }

        public async Task<CvModel> GetCV(Guid Cvid)
        {
            var entityCv = await _cvRepository.GetCVById(Cvid);
            return _mapper.Map<CvModel>(entityCv);
        }

        public async Task<InterviewerModel> GetInterviewerInformation(Guid applicationId)
        {
            var entityData = await _interviewerRepository.GetInterviewerById(applicationId);
            return _mapper.Map<InterviewerModel>(entityData);
        }

        public async Task<PositionModel> GetPosition(Guid applicationId)
        {
            var entityData = await _positionRepository.GetPositionById(applicationId);
            return _mapper.Map<PositionModel>(entityData);
        }

        public async Task<RoomModel> GetRoomInformation(Guid applicationId)
        {
            var interviewSetForApplication = await _interviewRepository.GetInterviewById(applicationId);

            var itrsForInterview = await _itrsinterviewRepository.GetItrsinterviewById(interviewSetForApplication!.ItrsinterviewId!.Value);

            var room = await _roomRepository.GetRoomById(itrsForInterview!.RoomId);
            return _mapper.Map<RoomModel>(room);
        }
    }
}