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
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { JWT } from '../../../data/authen/jwt.model';
import { ToastrService } from 'ngx-toastr';
import { BackendResponse } from '../../../data/response.interface';

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
		private route: ActivatedRoute,
		private CookieService: CookieService,
		private toasts: ToastrService
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
		this.loginData = this.loginForm.value;
		this.authService
			.login(this.loginData)
			.pipe(first())
			.subscribe({
				next: (data: any) => {
					if ('status' in data && data['status'] === 'Email need confirmed') {
						this.toasts.error(data.message, "Logged in failed", { timeOut: 3000, closeButton: true, progressBar: true });
						this.router.navigate(['/auth/confirm-email']);
						return;
					}
					else if ('accessToken' in data) {
						const jwtData: JWT = data as JWT;
						const expTime = new Date().getDate() + 30;
						this.CookieService.set('jwt', jwtData.accessToken, expTime, '/'); // save accesstoken
						this.CookieService.set('refreshToken', jwtData.refreshToken, expTime, '/') // save refreshtoken
						localStorage.setItem('expirationDate', jwtData.expirationDate); // save expirationDate

						this.authService.getCurrentUser().subscribe({
							next: (data) => {
								if (data !== null) {
									localStorage.setItem('currentUser', JSON.stringify(data));
									this.navigate_before();
									this.toasts.success("Logged in successfully", "Success", { timeOut: 3000, closeButton: true, progressBar: true });
								} else {
									this.authService.logout();
									this.toasts.warning("Cann't get user information", "Warning!!!", { timeOut: 3000, closeButton: true, progressBar: true });
								}
							}
						});
					}

				},
				error: (error) => {
					if (error.status === '401') {
						this.toasts.error(error.message, "Logged in failed", { timeOut: 3000, closeButton: true, progressBar: true });
						// this.authService.logout();
					}
				},
				complete: () => { },
			});
	}

	navigate_before(): void {
		this.route.queryParams.subscribe(params => {
			const returnUrl = params['returnUrl'] || '/';
			this.router.navigateByUrl(decodeURIComponent(returnUrl));
		});
	}
}
