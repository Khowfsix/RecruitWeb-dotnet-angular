using AutoMapper;
using Data.CustomModel.Application;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ICvRepository _cvRepository;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            ICvRepository cvRepository,
            IBlacklistRepository blacklistRepository,
            IMapper mapper
        )
        {
            _applicationRepository = applicationRepository;
            _cvRepository = cvRepository;
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteApplication(Guid applicationId)
        {
            return await _applicationRepository.DeleteApplication(applicationId);
        }

        public async Task<IEnumerable<ApplicationModel>> GetAllApplicationsByPositionId(Guid positionId, ApplicationFilter? applicationFilter, string? sortString, bool isAdmin)
        {
            var data = await _applicationRepository.GetAllApplicationsByPositionId(positionId, applicationFilter, sortString);
            if (!data.IsNullOrEmpty())
            {
                if (applicationFilter.NotInBlackList!.Value)
                {
                    var blackLists = await _blacklistRepository.GetAllBlackLists();
                    var candidateIdsInBlackList = blackLists.Select(o => o.CandidateId);
                    List<ApplicationModel> models = _mapper.Map<List<ApplicationModel>>(data);
                    return isAdmin ? models.Where(o => !candidateIdsInBlackList.Contains(o.Cv.CandidateId)) : models.Where(o => !candidateIdsInBlackList.Contains(o.Cv.CandidateId) && !o.IsDeleted);
                }
                List<ApplicationModel> listData = _mapper.Map<List<ApplicationModel>>(data);
                return isAdmin ? listData : listData.Where(o => !o.IsDeleted);
            }
            return null!;
        }

        public async Task<IEnumerable<ApplicationModel>> GetAllApplications()
        {
            var data = await _applicationRepository.GetAllApplications();
            if (!data.IsNullOrEmpty())
            {
                List<ApplicationModel> listData = _mapper.Map<List<ApplicationModel>>(data);
                return listData;
            }
            return null!;
        }

        //public async Task<bool> SaveApplication(ApplicationModel request)
        //{
        //    var candidateId = await _cvRepository.GetCandidateIdByCVId(request.CvId);
        //    var isInBlackList = await _blacklistRepository.CheckIsInBlackList(candidateId);
        //    var data = _mapper.Map<ApplicationModel>(request);
        //    if (isInBlackList)
        //    {
        //        data.Company_Status = "Rejected";
        //    }
        //    return await _applicationRepository.SaveApplication(data);
        //}

        //public async Task<bool> UpdateApplication(ApplicationModel request, Guid candidateId)
        //{
        //    var data = _mapper.Map<ApplicationModel>(request);
        //    return await _applicationRepository.UpdateApplication(data, candidateId);
        //}

        //public async Task<IEnumerable<ApplicationHistoryModel>> GetApplicationHistory(
        //    Guid candidateId
        //)
        //{
        //    return await _applicationRepository.GetApplicationHistory(candidateId);
        //}

        public async Task<ApplicationModel?> GetApplicationById(Guid ApplicationId)
        {
            var entityData = await _applicationRepository.GetApplicationById(ApplicationId);
            if (entityData != null)
            {
                var data = _mapper.Map<ApplicationModel>(entityData);
                return data;
            }
            return null!;
        }

        public async Task<IEnumerable<ApplicationModel>> GetAllApplicationsOfPosition(Guid? positionId, int? status, int? priority)
        {
            var modelDatas = await _applicationRepository.GetAllApplications();

            if (!modelDatas.IsNullOrEmpty())
            {
                var filteredData = modelDatas.Where(item =>
                    (
                        item.Position.PositionId.Equals(positionId) &&
                        (item.Company_Status! == status! || item.Candidate_Status! == status!) &&
                        item.Priority! == priority!
                    ));

                foreach (var item in modelDatas)
                {
                    List<ApplicationModel> listData = _mapper.Map<List<ApplicationModel>>(filteredData);
                    return listData;
                }
            }
            return null!;
        }

        //public async Task<IEnumerable<ApplicationModel>> GetAllApplicationsOfPosition(Guid? positionId)
        //{
        //    var data = await _applicationRepository.GetAllApplications();
        //    List<ApplicationModel> listData = new List<ApplicationModel>();
        //    if (data != null)
        //    {
        //        foreach (var item in data)
        //        {
        //            var obj = _mapper.Map<ApplicationModel>(item);
        //            listData.Add(obj);
        //        }
        //        return listData;
        //    }
        //    return null;
        //}

        public async Task<ApplicationModel> SaveApplication(ApplicationModel request)
        {
            var data = _mapper.Map<Application>(request);
            var blackList = await _blacklistRepository.GetAllBlackLists();
            var thisCv = await _cvRepository.GetCVById(request.Cvid);
            var canInBlacklist = blackList.Where(c => c.CandidateId == thisCv.CandidateId).ToList();

            // Add auto check candidate in blacklist ??
            if (canInBlacklist.Count > 0)
            {
                //candidate_status is "pending" default
                data.Candidate_Status = (int?)EApplicationCandidateStatus.PENDING;
                data.Company_Status = (int?)EApplicationCompanyStatus.PENDING;
            }

            var response = await _applicationRepository.SaveApplication(data);
            return _mapper.Map<ApplicationModel>(response);
        }

        public async Task<bool> UpdateApplication(ApplicationModel request, Guid applicationId)
        {
            var data = _mapper.Map<Application>(request);
            return await _applicationRepository.UpdateApplication(data, applicationId);
        }

        public async Task<IEnumerable<ApplicationModel>> GetApplicationHistory(Guid candidateId, bool isAdmin)
        {
            var entityDatas = await _applicationRepository.GetApplicationHistory(candidateId);
            if (!entityDatas.IsNullOrEmpty())
                return isAdmin ? _mapper.Map<List<ApplicationModel>>(entityDatas) : _mapper.Map<List<ApplicationModel>>(entityDatas.Where(o => !o.IsDeleted));
            return null!;
        }

        public async Task<IEnumerable<ApplicationModel>> GetApplicationsWithStatus(int status, int priority)
        {
            var entityDatas = await _applicationRepository.GetApplicationsWithStatus(status, priority);
            if (!entityDatas.IsNullOrEmpty())
                return _mapper.Map<List<ApplicationModel>>(entityDatas);
            return null!;
        }

        public async Task<bool> UpdateStatusApplication(Guid applicationId, int? Candidate_Status, int? Company_Status)
        {
            var oldData = await _applicationRepository.GetApplicationById(applicationId);

            //oldData = null;
            if (oldData == null)
            {
                return await Task.FromResult(false);
            }

            if (Candidate_Status.HasValue)
            {
                if (oldData.Candidate_Status == (int?)EApplicationCandidateStatus.PENDING && Candidate_Status.Value == (int?)EApplicationCandidateStatus.PASSED)
                    oldData!.Candidate_Status = Candidate_Status;
                else
                    return await Task.FromResult(false);
            }

            if (Company_Status.HasValue)
            {
                if (oldData.Company_Status!.Value < Company_Status.Value)
                    oldData!.Company_Status = Company_Status;
                else
                    return await Task.FromResult(false);
            }

            #region old status

            //if (data.Company_Status == "Pending")
            //{
            //    if (newStatus.Equals("Rejected"))
            //    {
            //        // Do nothing
            //    }
            //    else if (newStatus.Equals("Accepted"))
            //    {
            //        data.Candidate_Status = "Passed";
            //    }
            //    else if (newStatus.Equals("Pending"))
            //    {
            //        //It's default. Do nothing
            //    }
            //}
            //else if (newStatus.Equals("Accepted"))
            //{
            //    // Do nothing
            //}
            //else
            //{
            //    // newStatus == "Rejected"
            //    //Do nothing
            //}

            #endregion old status

            return await _applicationRepository.UpdateApplication(oldData, applicationId);
        }

        public async Task<ApplicationModel?> GetApplicationModelById(Guid applicationId)
        {
            var entityData = await _applicationRepository.GetApplicationById(applicationId);
            return _mapper.Map<ApplicationModel>(entityData);
        }
    }
}