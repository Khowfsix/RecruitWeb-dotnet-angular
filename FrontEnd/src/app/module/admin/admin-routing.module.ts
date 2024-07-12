import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AnalysisComponent } from './analysis/analysis.component';
import { ApplicationComponent } from './application/application.component';
import { AwardComponent } from './award/award.component';
import { BlackListComponent } from './black-list/black-list.component';
import { CandidateHasSkillComponent } from './candidate-has-skill/candidate-has-skill.component';
import { CandidateJoinEventComponent } from './candidate-join-event/candidate-join-event.component';
import { CandidateComponent } from './candidate/candidate.component';
import { CategoryPositionComponent } from './category-position/category-position.component';
import { CategoryQuestionComponent } from './category-question/category-question.component';
import { CertificateComponent } from './certificate/certificate.component';
import { CompanyComponent } from './company/company.component';
import { CVComponent } from './cv/cv.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EducationComponent } from './education/education.component';
import { EventHasPositionComponent } from './event-has-position/event-has-position.component';
import { EventComponent } from './event/event.component';
import { InterviewComponent } from './interview/interview.component';
import { InterviewerComponent } from './interviewer/interviewer.component';
import { LanguageComponent } from './language/language.component';
import { LevelComponent } from './level/level.component';
import { PersonalProjectComponent } from './personal-project/personal-project.component';
import { PositionComponent } from './position/position.component';
import { QuestionLanguageComponent } from './question-language/question-language.component';
import { QuestionSkillComponent } from './question-skill/question-skill.component';
import { QuestionComponent } from './question/question.component';
import { RecruiterComponent } from './recruiter/recruiter.component';
import { ReportComponent } from './report/report.component';
import { RequirementComponent } from './requirement/requirement.component';
import { RoleComponent } from './role/role.component';
import { RoundComponent } from './round/round.component';
import { SecurityAnswerComponent } from './security-answer/security-answer.component';
import { SecurityQuestionComponent } from './security-question/security-question.component';
import { SkillComponent } from './skill/skill.component';
import { SuccessfulCandidateComponent } from './successful-candidate/successful-candidate.component';
import { UserRoleComponent } from './user-role/user-role.component';
import { UserComponent } from './user/user.component';
import { WorkExperienceComponent } from './work-experience/work-experience.component';
import { ExportComponent } from './export/export.component';
import { ApproveRecruitersComponent } from './approve-recruiters/approve-recruiters.component';
import { UserManageComponent } from './user-manage/user-manage.component';

const routes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [
			//Dashboards
			// {
			// 	path: '',
			// 	component: DashboardComponent,
			// 	data: { breadcrumb: 'Overview' }

			// },
			{
				path: '',
				component: ReportComponent,
				data: { breadcrumb: 'Report' },
			},
			{
				path: 'overview',
				component: DashboardComponent,
				data: { breadcrumb: 'Overview' },
			},
			{
				path: 'reports',
				component: ReportComponent,
				data: { breadcrumb: 'Reports' },
			},
			{
				path: 'analytics',
				component: AnalysisComponent,
				data: { breadcrumb: 'Analytics' },
			},
			{
				path: 'user-manage',
				component: UserManageComponent,
				data: { breadcrumb: 'User manage' },
			},
			{
				path: 'exports',
				component: ExportComponent,
			},
			{
				path: 'approve-recruiters',
				component: ApproveRecruitersComponent,
			},

			//Table console
			{
				path: 'applications',
				component: ApplicationComponent,
			},
			{
				path: 'roles',
				component: RoleComponent,
			},
			{
				path: 'user-roles',
				component: UserRoleComponent,
			},
			{
				path: 'users',
				component: UserComponent,
			},
			{
				path: 'awards',
				component: AwardComponent,
			},
			{
				path: 'blacklists',
				component: BlackListComponent,
			},
			{
				path: 'candidates',
				component: CandidateComponent,
			},
			{
				path: 'candidate-has-skills',
				component: CandidateHasSkillComponent,
			},
			{
				path: 'candidate-join-events',
				component: CandidateJoinEventComponent,
			},
			{
				path: 'category-positions',
				component: CategoryPositionComponent,
			},
			{
				path: 'category-questions',
				component: CategoryQuestionComponent,
			},
			{
				path: 'certificates',
				component: CertificateComponent,
			},
			{
				path: 'companies',
				component: CompanyComponent,
			},
			{
				path: 'cvs',
				component: CVComponent,
			},
			{
				path: 'educations',
				component: EducationComponent,
			},
			{
				path: 'events',
				component: EventComponent,
			},
			{
				path: 'event-has-positions',
				component: EventHasPositionComponent,
			},
			{
				path: 'interviews',
				component: InterviewComponent,
			},
			{
				path: 'interviewers',
				component: InterviewerComponent,
			},
			{
				path: 'languages',
				component: LanguageComponent,
				data: { breadcrumb: 'Languages manage' },
			},
			{
				path: 'levels',
				component: LevelComponent,
			},
			{
				path: 'personal-projects',
				component: PersonalProjectComponent,
			},
			{
				path: 'positions',
				component: PositionComponent,
			},
			{
				path: 'questions',
				component: QuestionComponent,
			},
			{
				path: 'question-languages',
				component: QuestionLanguageComponent,
			},
			{
				path: 'question-skills',
				component: QuestionSkillComponent,
			},
			{
				path: 'recruiters',
				component: RecruiterComponent,
			},
			{
				path: 'requirements',
				component: RequirementComponent,
			},
			{
				path: 'rounds',
				component: RoundComponent,
			},
			{
				path: 'security-answers',
				component: SecurityAnswerComponent,
			},
			{
				path: 'security-questions',
				component: SecurityQuestionComponent,
			},
			{
				path: 'skills',
				component: SkillComponent,
			},
			{
				path: 'successful-candidates',
				component: SuccessfulCandidateComponent,
			},
			{
				path: 'work-experiences',
				component: WorkExperienceComponent,
			},
			// otherwise
			{ path: '**', redirectTo: '' },
		],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AdminRoutingModule {}
