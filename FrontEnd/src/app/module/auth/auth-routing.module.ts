import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { ConfirmYourEmailComponent } from './confirm-your-email/confirm-your-email.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

const routes: Routes = [
	{
		path: 'login',
		component: LoginComponent,
	},
	{
		path: 'register',
		component: RegisterComponent,
	},
	{
		path: 'profile',
		component: ProfileComponent,
	},
	{
		path: 'confirm-email',
		component: ConfirmYourEmailComponent
	},
	{
		path: 'forgot-password',
		component: ForgotPasswordComponent
	}
];

@NgModule({
	providers: [],
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AuthRoutingModule { }
