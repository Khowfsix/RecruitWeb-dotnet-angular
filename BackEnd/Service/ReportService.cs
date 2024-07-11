using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class ReportService : IReportService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;

        public ReportService(IApplicationRepository applicationRepository, IReportRepository reportRepository, IMapper mapper, IInterviewRepository interviewRepository)
        {
            _applicationRepository = applicationRepository;
            _reportRepository = reportRepository;
            _mapper = mapper;
            _interviewRepository = interviewRepository;
        }

        public async Task<ReportModel> SaveReport(ReportModel reportModel)
        {
            var entity = _mapper.Map<Report>(reportModel);
            var response = await _reportRepository.SaveReport(entity);
            return _mapper.Map<ReportModel>(response);
        }

        public async Task<bool> DeleteReport(Guid reportModelId)
        {
            return await _reportRepository.DeleteReport(reportModelId);
        }

        public async Task<IEnumerable<ReportModel>> GetAllReport()
        {
            var entites = await _reportRepository.GetAllReport();
            List<ReportModel> models = new List<ReportModel>();
            foreach (var item in entites)
            {
                models.Add(_mapper.Map<ReportModel>(item));
            }
            return models;
        }

        public async Task<bool> UpdateReport(ReportModel reportModel, Guid reportModelId)
        {
            var entity = _mapper.Map<Report>(reportModel);
            return await _reportRepository.UpdateReport(entity, reportModelId);
        }

        public async Task<IEnumerable<InterviewReportModel>> InterviewReport(DateTime fromDate, DateTime toDate)
        {
            var reportData = await _interviewRepository.InterviewReport(fromDate, toDate);

            var result = new List<InterviewReportModel>();

            foreach (var item in reportData)
            {
                var row = new InterviewReportModel()
                {
                    InterviewId = item.InterviewId,
                    CandidateId = item.Application.Cv.CandidateId,
                    InterviewerId = item.InterviewerId,
                    ApplyDate = item.Application.CreatedTime,
                    Status = (int)item.Company_Status!,
                    InterviewDate = item.MeetingDate.Value,
                    Score = item.Rounds.Average(x => x.Score) ?? 0,
                };

                result.Add(row);
            }

            return result;
        }

        public async Task<IEnumerable<ApplicationReportModel>> ApplicationReport(DateTime fromDate, DateTime toDate)
        {
            var reportData = await _applicationRepository.ApplicationReport(fromDate, toDate);

            var result = new List<ApplicationReportModel>();

            foreach (var item in reportData)
            {
                var row = new ApplicationReportModel()
                {
                    ApplicationId = item.ApplicationId,
                    FullName = item.Cv.Candidate.User.FullName,
                    DateOfBirth = item.Cv.Candidate.User.DateOfBirth.HasValue ? item.Cv.Candidate.User.DateOfBirth.Value : DateTime.MinValue,
                    Address = item.Cv.Candidate.User.Address,
                    //Experience = item.Cv.Experience,
                    //CvName = item.Cv.CvName,
                    //Introduction = item.Cv.Introduction,
                    //Education = item.Cv.Education,
                    PositionName = item.Position.PositionName,
                    Description = item.Position.Description,
                    MinSalary = item.Position.MinSalary,
                    MaxSalary = item.Position.MaxSalary,
                    CompanyName = item.Position.Company.CompanyName,
                    LanguageName = item.Position.Language.LanguageName,
                    CreatedTime = item.CreatedTime,
                    Candidate_Status = item.Candidate_Status,
                    Company_Status = item.Company_Status,
                    Priority = item.Priority,
                    IsDeleted = item.IsDeleted,
                };

                result.Add(row);
            }

            return result;
        }
    }
}