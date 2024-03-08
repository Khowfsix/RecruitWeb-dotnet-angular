using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<IInterviewService, InterviewService>();
            service.AddTransient<IInterviewerService, InterviewerService>();
            service.AddTransient<IItrsinterviewService, ItrsinterviewService>();
            service.AddTransient<IRecruiterService, RecruiterService>();
            service.AddTransient<ILanguageService, LanguageService>();
            service.AddTransient<IPositionService, PositionService>();
            service.AddTransient<IQuestionService, QuestionService>();
            service.AddTransient<IQuestionSkillService, QuestionSkillService>();
            service.AddTransient<IReportService, ReportService>();
            service.AddTransient<IRoundService, RoundService>();
            service.AddTransient<IShiftService, ShiftService>();
            service.AddTransient<ISkillService, SkillService>();
            service.AddTransient<ISuccessfulCandidateService, SuccessfulCandidateService>();
            service.AddTransient<IRequirementService, RequirementService>();
            service.AddTransient<IResultService, ResultService>();
            service.AddTransient<IRoomService, RoomService>();
            service.AddTransient<ICategoryQuestionService, CategoryQuestionService>();
            service.AddTransient<ICertificateService, CertificateService>();
            service.AddTransient<ICvService, CvService>();
            service.AddTransient<ICvHasSkillService, CvHasSkillService>();
            service.AddTransient<ICompanyService, CompanyService>();
            service.AddTransient<IEventService, EventService>();
            service.AddTransient<IApplicationService, ApplicationService>();
            service.AddTransient<IBlacklistService, BlacklistService>();
            service.AddTransient<ICandidateJoinEventService, CandidateJoinEventService>();
            service.AddTransient<ICandidateService, CandidateService>();
            service.AddTransient<IJobInterviewHistoryService, JobInterviewHistoryService>();
            service.AddTransient<IFileService, FileService>();
            service.AddTransient<IApplicationSuggestionService, ApplicationSuggestionService>();
            service.AddTransient<ISecurityAnswerService, SecurityAnswerService>();
            service.AddTransient<ISecurityQuestionService, SecurityQuestionService>();
            service.AddTransient<IAuthService, AuthService>();
            service.AddTransient<IEmailService, EmailService>();
            service.AddTransient<ICategoryPositionService, CategoryPositionService>();
            return service;
        }
    }
}