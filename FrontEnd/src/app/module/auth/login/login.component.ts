import { Component } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Login } from '../../../data/authen/login.model';
import {
	FormBuilder,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
	Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { JWT } from '../../../data/authen/jwt.model';

@Component({
	selector: 'app-login',
	standalone: true,
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss',
	imports: [FormsModule, ReactiveFormsModule],
})
export class LoginComponent {
	loginForm: FormGroup;
	loginData: Login = {
		username: '',
		password: '',
	};

	constructor(
		private fb: FormBuilder,
		private authService: AuthService,
		private router: Router,
		private CookieService: CookieService,
	) {
		this.loginForm = this.fb.group({
			username: ['', [Validators.required]],
			password: ['', [Validators.required]],
		});
	}

	onSubmit() {
		this.loginData = this.loginForm.value;
		this.authService
			.login(this.loginData)
			.pipe(first())
			.subscribe({
				next: (data) => {
					const jwtData: JWT = data as JWT;
					this.CookieService.set(
						'jwt',
						jwtData.token,
						Date.parse(jwtData.expiration),
					);
					this.authService.getCurrentUser().subscribe({
						next: (data) => {
							if (data !== null) {
								localStorage.setItem(
									'currentUser',
									JSON.stringify(data),
								);
							} else {
								console.log(`Cann't get user information`);
							}
						},
						error: (error) => {
							console.log(error);
						},
					});

					this.router.navigate(['']);
				},
				error: (error) => {
					console.log(error);
				},
				complete: () => {},
			});
	}
}
