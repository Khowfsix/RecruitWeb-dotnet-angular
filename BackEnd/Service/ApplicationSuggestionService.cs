using AutoMapper;
using Data.Interfaces;

using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class ApplicationSuggestionService : IApplicationSuggestionService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IRequirementRepository _requirementRepository;
        private readonly IMapper _mapper;

        public ApplicationSuggestionService(
            IApplicationRepository applicationRepository,
            IRequirementRepository requirementRepository,
            IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _requirementRepository = requirementRepository;
            _mapper = mapper;
        }

        public async Task<List<ApplicationModel>> GetSuggestion(Guid positionId)
        {
            List<(ApplicationModel, int)> applicationWithSkillMatchedCount = new();
            // Get all skills related to requirements
            var positionRequirementList = await _requirementRepository.GetRequirementsByPositionId(positionId);
            List<Guid> positionSkillList = positionRequirementList.Select(position => position.SkillId).ToList();
            // Check skills from cv list
            var applicationList = await _applicationRepository.GetAllApplications();
            foreach (var application in applicationList)
            {
                //var specificCvSkillIdList = specificCvSkillList.Select(cvSkill => cvSkill.Cvid).ToList();
                var numberOfMatchedSkill = (from positionSkill in positionSkillList
                                            select positionSkill).Count();

                var modelData = _mapper.Map<ApplicationModel>(application);
                applicationWithSkillMatchedCount.Add((modelData, numberOfMatchedSkill));
            }
            //var potentialSkillListMatch = positionSkillList.Zip(applicationList);

            List<(ApplicationModel, int)> orderedApplicationList = applicationWithSkillMatchedCount.OrderByDescending(count => count.Item2).ToList();
            List<ApplicationModel> result = orderedApplicationList.Select(r => r.Item1).ToList();
            return result;
        }
    }
}