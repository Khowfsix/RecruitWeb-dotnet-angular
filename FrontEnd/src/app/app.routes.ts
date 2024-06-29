import { Type } from '@angular/core';
import { Route, Routes } from '@angular/router';
import { AuthGuard } from './core/guard/auth.guard';
import { CandidateProfileComponent } from './module/cv/candidate-profile/candidate-profile.component';
import { CvManageComponent } from './module/cv/cv-manage/cv-manage.component';
import { CvComponent } from './module/cv/cv.component';
import { EventDetailComponent } from './module/event-detail/event-detail.component';
import { HomeComponent } from './module/home/home.component';
import { InfoCandidateComponent } from './module/interview/info-candidate/info-candidate.component';
import { InterviewQuestionsComponent } from './module/interview/interview-questions/interview-questions.component';
import { ListInterviewComponent } from './module/interview/list-interview/list-interview.component';
import { ZoomIntergrateComponent } from './module/interview/zoom-intergrate/zoom-intergrate.component';
import { PositionDetailComponent } from './module/position-detail/position-detail/position-detail.component';
import { PositionComponent } from './module/position/position.component';
import { ApplicationComponent } from './module/reccer/application/application.component';
import { CompanyComponent } from './module/reccer/company/company.component';
import { EventComponent } from './module/reccer/event/event.component';
import { InterviewComponent } from './module/reccer/interview/interview.component';
import { InterviewerComponent } from './module/reccer/interviewer/interviewer.component';
// import { UrlNotFoundComponent } from './shared/url-not-found/url-not-found.component';

const enum role {
	ADMIN = 'Admin',
	RECRUITER = 'Recruiter',
	INTERVIEWER = 'Interviewer',
	CANDIDATE = 'Candidate',
}

export const routes: Routes = [
	// home page
	{ path: '', component: HomeComponent },

	// url which is not need token
	{
		path: 'auth',
		loadChildren: () =>
			import('./module/auth/auth.module').then((m) => m.AuthModule),
	},

	// need authentication but no roles

	{ path: 'events/detail/:eventId', component: EventDetailComponent, data: { breadcrumb: 'Event Detail' } },

	{ path: 'positions/detail/:positionId', component: PositionDetailComponent, data: { breadcrumb: 'Position Detail' } },

	{ path: 'positions', component: PositionComponent, data: { breadcrumb: 'Positions' } },

	createRouteWithRoles('events', EventComponent, [
		role.RECRUITER,
		role.ADMIN,
	], 'Event Management'),

	createRouteWithRoles('applications/:positionId', ApplicationComponent, [
		role.RECRUITER,
		role.ADMIN,
	], 'Application Management'),

	createRouteWithRoles('interviewers', InterviewerComponent, [
		role.RECRUITER,
		role.ADMIN,
	], 'Interviewer Management'),

	createRouteWithRoles('interviews', InterviewComponent, [
		role.RECRUITER,
		role.ADMIN,
	], 'Interview Management'),

	// // url for recruiter
	createRouteWithRoles('companies', CompanyComponent, [
		role.RECRUITER,
		role.ADMIN,
		role.CANDIDATE,
		role.INTERVIEWER
	], 'Company '),

	// url for interviewer
	createRouteWithRoles('list-interviews', ListInterviewComponent, [
		role.INTERVIEWER,
		role.ADMIN
	], 'List Interview'),
	createRouteWithRoles('candidate-infomation', InfoCandidateComponent, [
		role.INTERVIEWER,
		role.ADMIN
	], 'Candidate Infomation'),
	createRouteWithRoles('interview-questions', InterviewQuestionsComponent, [
		role.INTERVIEWER,
		role.CANDIDATE,
		role.ADMIN
	], 'Interview Questions'),
	createRouteWithRoles('zoom-interview', ZoomIntergrateComponent, [
		role.ADMIN,
		role.INTERVIEWER,
		role.CANDIDATE
	], 'Zoom Intergrate'),

	// url for candidate
	createRouteWithRoles('cv', CvComponent, [role.CANDIDATE], 'Cv Management'),
	createRouteWithRoles('profile', CandidateProfileComponent, [role.CANDIDATE], 'Candidate Profile'),
	createRouteWithRoles('cv-manage', CvManageComponent, [role.CANDIDATE], 'Cv Manage'),
	// createRouteWithRoles('cv/candidateProfile', CandidateProfileComponent, [role.CANDIDATE]),
	// createRouteWithRoles('cv/cvManage', CvManageComponent, [role.CANDIDATE]),
	// createRouteWithRoles('cv/jobPreference', JobPreferenceComponent, [role.CANDIDATE]),

	// url for admin
	{
		path: 'admin',
		loadChildren: () =>
			import('./module/admin/admin.module').then((m) => m.AdminModule),
		canActivate: [AuthGuard],
		data: { roles: [role.ADMIN], breadcrumb: 'Admin dashboard' },
	},

	// otherwise redirect to home
	{ path: '**', redirectTo: '' },
	// {path: "**", title: "UrlNotFound", component: UrlNotFoundComponent}
];

function createRouteWithRoles(
	url: string,
	component: Type<unknown>,
	roles: string[],
	breadcrumb?: string
): Route {
	return {
		path: url,
		component: component,
		canActivate: [AuthGuard],
		data: {
			roles: roles,
			breadcrumb: breadcrumb
		},
	};
}
