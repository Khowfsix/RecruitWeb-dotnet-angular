import { Routes } from '@angular/router';
import { PositionComponent } from './module/reccer/position/position.component';
import { HomeComponent } from './module/home/home.component';
// import { UrlNotFoundComponent } from './shared/url-not-found/url-not-found.component';

export const routes: Routes = [
	{
		path: 'auth',
		loadChildren: () =>
			import('./module/auth/auth.module').then((m) => m.AuthModule),
	},
	{ path: 'position', component: PositionComponent },

	{ path: '', redirectTo: '/home', pathMatch: 'full' },
	{ path: 'home', component: HomeComponent },
	// { path: '', redirectTo: '/', pathMatch: 'full' },
	// { path: '**', title: 'UrlNotFound', component: UrlNotFoundComponent },
	// { path: 'position', component: PositionComponent },
	// {path: "", redirectTo: "/", pathMatch: "full"},
	// {path: "**", title: "UrlNotFound", component: UrlNotFoundComponent}
];
