import { Routes } from '@angular/router';
import { PositionComponent } from './module/reccer/position/position.component';
import { authGuard } from './core/guard/auth.guard';
// import { UrlNotFoundComponent } from './shared/url-not-found/url-not-found.component';

export const routes: Routes = [
	{
		path: 'auth',
		loadChildren: () =>
			import('./module/auth/auth.module').then((m) => m.AuthModule),
		canActivate: [authGuard],
	},
	{ path: 'position', component: PositionComponent },
	// { path: '', redirectTo: '/', pathMatch: 'full' },
	// { path: '**', title: 'UrlNotFound', component: UrlNotFoundComponent },
	// { path: 'position', component: PositionComponent },
	// {path: "", redirectTo: "/", pathMatch: "full"},
	// {path: "**", title: "UrlNotFound", component: UrlNotFoundComponent}
];
