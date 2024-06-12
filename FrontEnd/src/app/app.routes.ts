import { Route, Routes } from '@angular/router';
import { PositionComponent } from './module/position/position.component';
import { HomeComponent } from './module/home/home.component';
import { CompanyComponent } from './module/reccer/company/company.component';
import { AuthGuard } from './core/guard/auth.guard';
import { Type } from '@angular/core';
import { PositionDetailComponent } from './module/position-detail/position-detail/position-detail.component';
import { ApplicationComponent } from './module/reccer/application/application.component';
import { CvComponent } from './module/cv/cv.component';
import { InterviewerComponent } from './module/reccer/interviewer/interviewer.component';
import { InterviewComponent } from './module/reccer/interview/interview.component';
import { CandidateProfileComponent } from './module/cv/candidate-profile/candidate-profile.component';
import { CvManageComponent } from './module/cv/cv-manage/cv-manage.component';
import { ListInterviewComponent } from './module/interview/list-interview/list-interview.component';
import { InfoCandidateComponent } from './module/interview/info-candidate/info-candidate.component';
import { InterviewQuestionsComponent } from './module/interview/interview-questions/interview-questions.component';
import { ZoomIntergrateComponent } from './module/interview/zoom-intergrate/zoom-intergrate.component';
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

	{ path: 'positions/detail/:positionId', component: PositionDetailComponent },

	{ path: 'positions', component: PositionComponent },

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
	createRouteWithRoles('list-interviews', ListInterviewComponent, [
		role.INTERVIEWER,
		role.ADMIN
	]),
	createRouteWithRoles('candidate-infomation', InfoCandidateComponent, [
		role.INTERVIEWER,
		role.ADMIN
	]),
	createRouteWithRoles('interview-questions', InterviewQuestionsComponent, [
		role.INTERVIEWER,
		role.CANDIDATE,
		role.ADMIN
	]),
	createRouteWithRoles('zoom-interview', ZoomIntergrateComponent, [
		role.ADMIN,
		role.INTERVIEWER,
		role.CANDIDATE
	]),

	// url for candidate
	createRouteWithRoles('cv', CvComponent, [role.CANDIDATE]),
	createRouteWithRoles('profile', CandidateProfileComponent, [role.CANDIDATE]),
	createRouteWithRoles('cv-manage', CvManageComponent, [role.CANDIDATE]),
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
