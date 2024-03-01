import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { Login } from '../../../data/authen/login.model';

@Component({
	selector: 'app-login',
	standalone: true,
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss',
	imports: [],
})
export class LoginComponent {
	constructor(private router: Router, private authService: AuthService) {}

	loginData: Login = {
		username: '',
		password: '',
	};
	hide: boolean = true;

	onSubmit() {
		// this.authService.login(this.loginData).subscribe({
		// 	next: (data: unknown) => {
		// 		console.log(data);
		// 	},
		// 	error: (error: unknown) => {
		// 		console.log(error);
		// 	},
		// 	complete: () => {
		// 		this.router.navigate(['/home']);
		// 	},
		// });
		console.log(`click`);
	}
}
