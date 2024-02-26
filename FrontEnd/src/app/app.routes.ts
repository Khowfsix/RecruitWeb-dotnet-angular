import { Routes } from '@angular/router';
import { PositionComponent } from './module/reccer/position/position.component';
import { UrlNotFoundComponent } from './shared/url-not-found/url-not-found.component';

export const routes: Routes = [
	{
		path: 'auth',
		loadChildren: () =>
			import('./module/auth/auth.module').then((m) => m.AuthModule),
	},
	{ path: 'position', component: PositionComponent },
	{ path: '', redirectTo: '/', pathMatch: 'full' },
	{ path: '**', title: 'UrlNotFound', component: UrlNotFoundComponent },
];
