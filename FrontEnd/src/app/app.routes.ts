import { Route, Routes } from '@angular/router';
import { PositionComponent } from './module/reccer/position/position.component';
import { HomeComponent } from './module/home/home.component';
import { CompanyComponent } from './module/reccer/company/company.component';
import { AuthGuard } from './core/guard/auth.guard';
import { Type } from '@angular/core';
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

	// url for recruiter
	createRouteWithRoles('companies', CompanyComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),
	createRouteWithRoles('positions', PositionComponent, [
		role.RECRUITER,
		role.ADMIN,
	]),

	// url for interviewer

	// url for candidate

	// url for admin

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
