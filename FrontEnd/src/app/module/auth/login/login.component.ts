import { Component, OnInit } from '@angular/core';
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
export class LoginComponent implements OnInit {
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
	ngOnInit(): void {
		// console.error(`init`);
	}

	onSubmit() {
		console.error(`aaaaa`);
		this.loginData = this.loginForm.value;
		console.log(`Login data: ${JSON.stringify(this.loginData)}`);
		this.authService
			.login(this.loginData)
			.pipe(first())
			.subscribe({
				next: (data) => {
					const jwtData: JWT = data as JWT;
					console.log(jwtData);

					this.CookieService.set('jwt', jwtData.accessToken); // save accesstoken
					this.CookieService.set('refreshToken', jwtData.refreshToken) // save refreshtoken
					localStorage.setItem('expirationDate', jwtData.expirationDate); // save expirationDate

					this.authService.getCurrentUser().subscribe({
						next: (data) => {
							console.log(data);
							if (data !== null) {
								// this.CookieService.set(
								// 	'currentUser',
								// 	JSON.stringify(data),
								// );
								localStorage.setItem('currentUser', JSON.stringify(data));
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
				complete: () => { },
			});
	}
}
