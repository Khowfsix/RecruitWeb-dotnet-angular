import { Route, Routes } from '@angular/router';
import { PositionComponent } from './module/position/position.component';
import { HomeComponent } from './module/home/home.component';
import { CompanyComponent } from './module/reccer/company/company.component';
import { AuthGuard } from './core/guard/auth.guard';
import { Type } from '@angular/core';
import { PositionDetailComponent } from './module/position-detail/position-detail/position-detail.component';
import { ProfileComponent } from './module/auth/profile/profile.component';
import { ApplicationComponent } from './module/reccer/application/application.component';
import { CvComponent } from './module/cv/cv.component';
import { InterviewerComponent } from './module/reccer/interviewer/interviewer.component';
import { InterviewComponent } from './module/reccer/interview/interview.component';
import { CandidateProfileComponent } from './module/cv/candidate-profile/candidate-profile.component';
import { CvManageComponent } from './module/cv/cv-manage/cv-manage.component';
import { JobPreferenceComponent } from './module/cv/job-preference/job-preference.component';
import { EventComponent } from './module/reccer/event/event.component';
import { EventDetailComponent } from './module/event-detail/event-detail.component';
import { LoginMeetComponent } from './shared/component/gg-meet/login-meet/login-meet.component';
import { CallBackComponent } from './shared/component/gg-meet/call-back/call-back.component';
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
	{
		path: 'profile',
		component: ProfileComponent,
		canActivate: [AuthGuard],
		data: { roles: [] },
	},

	{ path: 'events/detail/:eventId', component: EventDetailComponent },

	{ path: 'positions/detail/:positionId', component: PositionDetailComponent },

	{ path: 'positions', component: PositionComponent },

	{ path: 'meet/login', component: LoginMeetComponent },
	{ path: 'meet/login/callback', component: CallBackComponent },

	createRouteWithRoles('events', EventComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),

	createRouteWithRoles('applications/:positionId', ApplicationComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),

	createRouteWithRoles('interviewers', InterviewerComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),

	createRouteWithRoles('interviews', InterviewComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),

	// // url for recruiter
	createRouteWithRoles('companies', CompanyComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),

	// url for interviewer

	// url for candidate
	createRouteWithRoles('cv', CvComponent, [role.CANDIDATE]),
	// createRouteWithRoles('cv/candidateProfile', CandidateProfileComponent, [role.CANDIDATE]),
	// createRouteWithRoles('cv/cvManage', CvManageComponent, [role.CANDIDATE]),
	// createRouteWithRoles('cv/jobPreference', JobPreferenceComponent, [role.CANDIDATE]),

	// url for admin
	{
		path: 'admin',
		loadChildren: () =>
			import('./module/admin/admin.module').then((m) => m.AdminModule),
		canActivate: [AuthGuard],
		data: { roles: [role.ADMIN] },
	},

	// otherwise redirect to home
	{ path: '**', redirectTo: '' },
	// {path: "**", title: "UrlNotFound", component: UrlNotFoundComponent}
];

function createRouteWithRoles(
	url: string,
	component: Type<unknown>,
	roles: string[],
): Route {
	return {
		path: url,
		component: component,
		canActivate: [AuthGuard],
		data: { roles: roles },
	};
}
