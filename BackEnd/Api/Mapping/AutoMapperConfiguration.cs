using Api.ViewModels;
using Api.ViewModels.Application;
using Api.ViewModels.AdminAward;
using Api.ViewModels.BlackList;
using Api.ViewModels.Candidate;
using Api.ViewModels.CandidateHasSkill;
using Api.ViewModels.CandidateJoinEvent;
using Api.ViewModels.CategoryPosition;
using Api.ViewModels.CategoryQuestion;
using Api.ViewModels.Certificate;
using Api.ViewModels.Company;
using Api.ViewModels.Cv;
using Api.ViewModels.CvHasSkill;
using Api.ViewModels.Event;
using Api.ViewModels.EventHasPosition;
using Api.ViewModels.Interview;
using Api.ViewModels.Interviewer;
using Api.ViewModels.Itrsinterview;
using Api.ViewModels.Language;
using Api.ViewModels.Level;
using Api.ViewModels.Position;
using Api.ViewModels.Question;
using Api.ViewModels.QuestionSkill;
using Api.ViewModels.Recruiter;
using Api.ViewModels.Report;
using Api.ViewModels.Requirement;
using Api.ViewModels.Result;
using Api.ViewModels.Role;
using Api.ViewModels.Room;
using Api.ViewModels.Round;
using Api.ViewModels.SecurityAnswer;
using Api.ViewModels.SecurityQuestion;
using Api.ViewModels.Shift;
using Api.ViewModels.Skill;
using Api.ViewModels.SuccessfulCadidate;
using Api.ViewModels.User;
using Api.ViewModels.UserRole;
using AutoMapper;
using Data.CustomModel.Application;
using Data.CustomModel.Event;
using Data.CustomModel.Interviewer;
using Data.CustomModel.Position;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Models;
using Api.ViewModels.AdminEducation;
using Api.ViewModels.AdminPersonalProject;
using Api.ViewModels.AdminQuestionLanguage;
using Api.ViewModels.AdminWorkExperience;

namespace Data.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region WorkExperience
            CreateMap<WorkExperienceViewModel, WorkExperienceModel>().ReverseMap();
            CreateMap<WorkExperienceModel, WorkExperience>().ReverseMap();
            #endregion WorkExperience

            #region QuestionLanguage
            CreateMap<QuestionLanguageViewModel, QuestionLanguageModel>().ReverseMap();
            CreateMap<QuestionLanguageModel, QuestionLanguage>().ReverseMap();
            #endregion QuestionLanguage

            #region PersonalProject
            CreateMap<PersonalProjectViewModel, PersonalProjectModel>().ReverseMap();
            CreateMap<PersonalProjectModel, PersonalProject>().ReverseMap();
            #endregion PersonalProject

            #region Education
            CreateMap<EducationViewModel, EducationModel>().ReverseMap();
            CreateMap<EducationModel, Education>().ReverseMap();
            #endregion Education

            #region Award
            CreateMap<AwardViewModel, AwardModel>().ReverseMap();
            CreateMap<AwardModel, Award>().ReverseMap();
            #endregion Award

            #region User
            CreateMap<AdminUserViewModel, UserModel>().ReverseMap();
            #endregion User

            #region UserRole
            CreateMap<UserRoleViewModel, UserRoleModel>().ReverseMap();
            CreateMap<UserRoleDeleteModel, UserRoleModel>().ReverseMap();
            CreateMap<UserRoleAddModel, UserRoleModel>().ReverseMap();
            CreateMap<UserRoleModel, IdentityUserRole<string>>().ReverseMap();
            #endregion UserRole

            #region Role
            CreateMap<RoleUpdateModel, RoleModel>().ReverseMap();
            CreateMap<RoleViewModel, RoleModel>().ReverseMap();
            CreateMap<RoleAddModel, RoleModel>().ReverseMap();
            CreateMap<RoleModel, IdentityRole>().ReverseMap();
            #endregion Role

            #region EventHasPosition

            CreateMap<EventHasPosition, EventHasPositionModel>().ReverseMap();
            CreateMap<EventHasPositionViewModel, EventHasPositionModel>().ReverseMap();
            CreateMap<EventHasPositionAddModel, EventHasPositionModel>().ReverseMap();
            CreateMap<EventHasPositionUpdateModel, EventHasPositionModel>().ReverseMap();

            #endregion EventHasPosition

            #region CandidateHasSkill

            CreateMap<CandidateHasSkill, CandidateHasSkillModel>().ReverseMap();
            CreateMap<CandidateHasSkillViewModel, CandidateHasSkillModel>().ReverseMap();

            #endregion CandidateHasSkill

            #region Level
            CreateMap<Level, LevelModel>().ReverseMap();
            CreateMap<LevelModel, LevelViewModel>().ReverseMap();
            CreateMap<LevelModel, LevelAddModel>().ReverseMap();
            CreateMap<LevelModel, LevelUpdateModel>().ReverseMap();
            #endregion Level

            #region CategoryPosition
            CreateMap<CategoryPosition, CategoryPositionModel>().ReverseMap();
            CreateMap<CategoryPositionModel, CategoryPositionViewModel>().ReverseMap();
            CreateMap<CategoryPositionModel, CategoryPositionAddModel>().ReverseMap();
            CreateMap<CategoryPositionModel, CategoryPositionUpdateModel>().ReverseMap();
            #endregion CategoryPosition

            #region Language

            CreateMap<Language, LanguageModel>().ReverseMap();
            CreateMap<LanguageModel, LanguageViewModel>().ReverseMap();
            CreateMap<LanguageModel, LanguageAddModel>().ReverseMap();
            CreateMap<LanguageModel, LanguageUpdateModel>().ReverseMap();

            #endregion Language

            #region Position

            CreateMap<Position, PositionViewModel>().ReverseMap();
            CreateMap<PositionModel, PositionModel>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is Guid guidValue)
                    {
                        if (guidValue == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                            return false;
                    }

                    if (srcMember == null)
                    {
                        return false;
                    }

                    return true;
                }));
            //.ForMember(dest => dest.CompanyId, opt => opt.Ignore())
            //.ForMember(dest => dest.RecruiterId, opt => opt.Ignore())
            //.ForMember(dest => dest.Requirements, opt => opt.Ignore());
            CreateMap<Position, PositionModel>().ReverseMap();
            CreateMap<Position, PositionViewModel>().ReverseMap();
            CreateMap<PositionModel, PositionViewModel>().ReverseMap();
            CreateMap<PositionModel, PositionAddModel>().ReverseMap();
            CreateMap<PositionUpdateModel, PositionModel>().ReverseMap();
            CreateMap<PositionFilter, PositionFilterModel>().ReverseMap();

            #endregion Position

            #region Question

            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<Question, QuestionModel>().ReverseMap();
            CreateMap<QuestionModel, QuestionAddModel>().ReverseMap();
            CreateMap<QuestionModel, QuestionUpdateModel>().ReverseMap();
            CreateMap<QuestionModel, QuestionViewModel>().ReverseMap();

            #endregion Question

            #region QuestionSkill

            CreateMap<QuestionSkill, QuestionSkillModel>().ReverseMap();
            CreateMap<QuestionSkillModel, QuestionSkillAddModel>().ReverseMap();
            CreateMap<QuestionSkillModel, QuestionSkillUpdateModel>().ReverseMap();
            CreateMap<QuestionSkillModel, QuestionSkillViewModel>().ReverseMap();

            #endregion QuestionSkill

            #region Recruiter

            CreateMap<Recruiter, RecruiterModel>().ReverseMap();
            CreateMap<RecruiterModel, RecruiterAddModel>().ReverseMap();
            CreateMap<RecruiterModel, RecruiterUpdateModel>().ReverseMap();
            CreateMap<RecruiterModel, RecruiterViewModel>().ReverseMap();
            CreateMap<Recruiter, RecruiterViewModel>().ReverseMap();

            #endregion Recruiter

            #region Report

            CreateMap<ApplicationReportModel, ApplicationReportViewModel>().ReverseMap();
            CreateMap<InterviewReportModel, InterviewReportViewModel>().ReverseMap();
            CreateMap<Report, ReportModel>().ReverseMap();
            CreateMap<Report, ReportViewModel>().ReverseMap();
            CreateMap<ReportModel, ReportAddModel>().ReverseMap();
            CreateMap<ReportModel, ReportUpdateModel>().ReverseMap();
            CreateMap<ReportModel, ReportViewModel>().ReverseMap();

            #endregion Report

            #region Requirement

            CreateMap<Requirement, RequirementModel>().ReverseMap();
            CreateMap<RequirementModel, RequirementAddModel>().ReverseMap();
            CreateMap<RequirementModel, RequirementUpdateModel>().ReverseMap();
            CreateMap<RequirementModel, RequirementViewModel>().ReverseMap();

            #endregion Requirement

            #region Result

            CreateMap<Result, ResultModel>().ReverseMap();
            CreateMap<ResultModel, ResultAddModel>().ReverseMap();
            CreateMap<ResultModel, ResultUpdateModel>().ReverseMap();
            CreateMap<ResultModel, ResultViewModel>().ReverseMap();

            #endregion Result

            #region Room

            CreateMap<Room, RoomModel>().ReverseMap();
            CreateMap<RoomModel, RoomAddModel>().ReverseMap();
            CreateMap<RoomModel, RoomUpdateModel>().ReverseMap();
            CreateMap<RoomModel, RoomViewModel>().ReverseMap();

            #endregion Room

            #region Round

            CreateMap<Round, RoundModel>().ReverseMap();
            CreateMap<Round, RoundViewModel>().ReverseMap();
            CreateMap<RoundModel, RoundAddModel>().ReverseMap();
            CreateMap<RoundModel, RoundUpdateModel>().ReverseMap();
            CreateMap<RoundModel, RoundViewModel>().ReverseMap();

            #endregion Round

            #region Shift

            CreateMap<Shift, ShiftModel>().ReverseMap();
            CreateMap<ShiftModel, ShiftAddModel>().ReverseMap();
            CreateMap<ShiftModel, ShiftUpdateModel>().ReverseMap();
            CreateMap<ShiftModel, ShiftViewModel>().ReverseMap();

            #endregion Shift

            #region Skill

            CreateMap<SkillModel, Skill>().ReverseMap();
            CreateMap<SkillModel, SkillAddModel>().ReverseMap();
            CreateMap<SkillModel, SkillUpdateModel>().ReverseMap();
            CreateMap<SkillModel, SkillViewModel>().ReverseMap();

            #endregion Skill

            #region SuccessfulCadidate

            CreateMap<SuccessfulCadidate, SuccessfulCadidateModel>().ReverseMap();
            CreateMap<SuccessfulCadidateModel, SuccessfulCadidateAddModel>().ReverseMap();
            CreateMap<SuccessfulCadidateModel, SuccessfulCadidateUpdateModel>().ReverseMap();
            CreateMap<SuccessfulCadidateModel, SuccessfulCadidateViewModel>().ReverseMap();

            #endregion SuccessfulCadidate

            #region Application

            CreateMap<ApplicationFilter, ApplicationFilterModel>().ReverseMap();
            CreateMap<Application, ApplicationModel>().ReverseMap();
            CreateMap<Application, ApplicationViewModel>().ReverseMap();
            CreateMap<ApplicationModel, ApplicationViewModel>().ReverseMap();
            CreateMap<ApplicationModel, ApplicationAddModel>().ReverseMap();
            CreateMap<ApplicationModel, ApplicationUpdateModel>().ReverseMap();
            CreateMap<ApplicationModel, ApplicationViewModel>().ReverseMap();
            CreateMap<ApplicationModel, ApplicationHistoryViewModel>().ReverseMap();

            #endregion Application

            #region BlackList

            CreateMap<BlackList, BlacklistModel>().ReverseMap();
            CreateMap<BlacklistModel, BlackListAddModel>().ReverseMap();
            CreateMap<BlacklistModel, BlackListUpdateModel>().ReverseMap();
            CreateMap<BlacklistModel, BlacklistViewModel>().ReverseMap();

            #endregion BlackList

            #region Candidate

            CreateMap<Candidate, CandidateModel>().ReverseMap();
            CreateMap<Candidate, CandidateViewModel>().ReverseMap();
            CreateMap<CandidateModel, CandidateAddModel>().ReverseMap();
            CreateMap<CandidateModel, CandidateUpdateModel>().ReverseMap();
            CreateMap<CandidateModel, Api.ViewModels.Candidate.CandidateViewModel>().ReverseMap();
            CreateMap<Candidate, CandidateViewModel>().ReverseMap();

            #endregion Candidate

            #region Profile Candidate

            CreateMap<Candidate, ProfileModel>().ReverseMap();
            CreateMap<ProfileModel, ProfileViewModel>().ReverseMap();

            #endregion Profile Candidate

            #region CandidateJoinEvent

            CreateMap<CandidateJoinEvent, CandidateJoinEventModel>().ReverseMap();
            CreateMap<CandidateJoinEvent, CandidateJoinEventViewModel>().ReverseMap();
            CreateMap<CandidateJoinEventModel, CandidateJoinEventAddModel>().ReverseMap();
            CreateMap<CandidateJoinEventModel, CandidateJoinEventUpdateModel>().ReverseMap();
            CreateMap<CandidateJoinEventModel, CandidateJoinEventViewModel>().ReverseMap();
            CreateMap<CandidateJoinEvent, CandidateJoinedEvent>().ReverseMap();
            CreateMap<CandidateJoinEventModel, CandidateJoinedEvent>().ReverseMap();
            CreateMap<CandidateJoinEvent, CandidateJoinEventModel>().ReverseMap();

            #endregion CandidateJoinEvent

            #region CategoryQuestion

            CreateMap<CategoryQuestion, CategoryQuestionModel>().ReverseMap();
            CreateMap<CategoryQuestionModel, CategoryQuestionAddModel>().ReverseMap();
            CreateMap<CategoryQuestionModel, CategoryQuestionUpdateModel>().ReverseMap();
            CreateMap<CategoryQuestionModel, CategoryQuestionViewModel>().ReverseMap();

            #endregion CategoryQuestion

            #region Certificate

            CreateMap<Certificate, CertificateModel>().ReverseMap();
            CreateMap<CertificateModel, CertificateAddModel>().ReverseMap();
            CreateMap<CertificateModel, CertificateUpdateModel>().ReverseMap();
            CreateMap<CertificateModel, CertificateViewModel>().ReverseMap();
            CreateMap<Certificate, CertificateViewModel>().ReverseMap();

            #endregion Certificate

            #region Cv

            CreateMap<Cv, CvModel>().ReverseMap();
            CreateMap<CvModel, CvAddModel>().ReverseMap();
            CreateMap<CvModel, CvUpdateModel>().ReverseMap();
            CreateMap<CvModel, CvViewModel>().ReverseMap();
            CreateMap<CvAddModel, CvViewModel>().ReverseMap();
            CreateMap<Cv, CvViewModel>().ReverseMap();

            #endregion Cv

            #region CvHasSkill

            CreateMap<CvHasSkill, CvHasSkillModel>().ReverseMap();
            CreateMap<CvHasSkillModel, CvHasSkillAddModel>().ReverseMap();
            CreateMap<CvHasSkillModel, CvHasSkillUpdateModel>().ReverseMap();
            CreateMap<CvHasSkillModel, CvHasSkillViewModel>().ReverseMap();

            #endregion CvHasSkill

            #region Company

            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<CompanyModel, CompanyViewModel>().ReverseMap();
            CreateMap<CompanyModel, CompanyUpdateModel>().ReverseMap();
            CreateMap<CompanyModel, CompanyAddModel>().ReverseMap();

            #endregion Company

            #region Event

            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Event, EventModel>().ReverseMap();
            CreateMap<EventFilter, EventFilterModel>().ReverseMap();
            CreateMap<EventModel, EventAddModel>().ReverseMap();
            CreateMap<EventModel, EventUpdateModel>().ReverseMap();
            CreateMap<EventModel, EventViewModel>().ReverseMap();

            #endregion Event

            #region Itrsinterview

            CreateMap<Itrsinterview, ItrsinterviewModel>().ReverseMap();
            CreateMap<ItrsinterviewModel, ItrsinterviewAddModel>().ReverseMap();
            CreateMap<ItrsinterviewModel, ItrsinterviewUpdateModel>().ReverseMap();
            CreateMap<ItrsinterviewModel, ItrsinterviewViewModel>().ReverseMap();

            #endregion Itrsinterview

            #region Interview
            CreateMap<Interview, Interview>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
               {
                   if (srcMember is Guid guidValue)
                   {
                       if (guidValue == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                           return false;
                   }

                   if (srcMember == null)
                   {
                       return false;
                   }

                   return true;
               }));
            CreateMap<InterviewFilter, InterviewFilterModel>().ReverseMap();
            CreateMap<Interview, InterviewViewModel>().ReverseMap();
            CreateMap<Interview, InterviewModel>().ReverseMap();
            CreateMap<InterviewModel, InterviewUpdateModel>().ReverseMap();
            CreateMap<InterviewModel, InterviewAddModel>().ReverseMap();
            CreateMap<InterviewModel, InterviewViewModel>().ReverseMap();
            #endregion Interview

            #region Interviewer

            CreateMap<InterviewerFilter, InterviewerFilterModel>().ReverseMap();
            CreateMap<Interviewer, InterviewerModel>().ReverseMap();
            CreateMap<InterviewerModel, InterviewerAddModel>().ReverseMap();
            CreateMap<InterviewerModel, InterviewerUpdateModel>().ReverseMap();
            CreateMap<InterviewerModel, InterviewerViewModel>().ReverseMap();
            CreateMap<Interviewer, InterviewerViewModel>().ReverseMap();

            #endregion Interviewer

            #region Itrsinterview

            CreateMap<Itrsinterview, ItrsinterviewModel>().ReverseMap();
            CreateMap<ItrsinterviewModel, ItrsinterviewAddModel>().ReverseMap();
            CreateMap<ItrsinterviewModel, ItrsinterviewUpdateModel>().ReverseMap();
            CreateMap<ItrsinterviewModel, ItrsinterviewViewModel>().ReverseMap();

            #endregion Itrsinterview

            #region SecurityQuestion

            CreateMap<SecurityQuestion, SecurityQuestionModel>().ReverseMap();
            CreateMap<SecurityQuestionModel, SecurityQuestionViewModel>().ReverseMap();
            CreateMap<SecurityQuestionModel, SecurityQuestionAddModel>().ReverseMap();
            CreateMap<SecurityQuestionModel, SecurityQuestionUpdateModel>().ReverseMap();

            #endregion SecurityQuestion

            #region SecurityAnswer

            CreateMap<SecurityAnswer, SecurityAnswerModel>().ReverseMap();
            CreateMap<SecurityAnswerModel, SecurityAnswerViewModel>().ReverseMap();
            CreateMap<SecurityAnswerModel, SecurityAnswerAddModel>().ReverseMap();
            CreateMap<SecurityAnswerModel, SecurityAnswerUpdateModel>().ReverseMap();

            #endregion SecurityAnswer

            #region WebUser

            CreateMap<WebUser, UserViewModel>().ReverseMap();
            CreateMap<WebUser, WebUserViewModel>().ReverseMap();
            CreateMap<WebUser, ProfileViewModel>().ReverseMap();

            CreateMap<WebUser, UserModel>().ReverseMap();
            CreateMap<WebUser, WebUserModel>().ReverseMap();

            CreateMap<WebUserModel, WebUserViewModel>().ReverseMap();
            CreateMap<UserModel, WebUserViewModel>().ReverseMap();

            #endregion WebUser

            CreateMap<RefreshToken, RefreshTokenModel>().ReverseMap();
        }
    }
}