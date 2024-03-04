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

@Component({
	selector: 'app-login',
	standalone: true,
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss',
	imports: [FormsModule, ReactiveFormsModule],
})
export class LoginComponent {
	loginForm: FormGroup;

	constructor(
		private fb: FormBuilder,
		private authService: AuthService,
		private router: Router,
	) {
		if (authService.isAuthenticated()) {
			router.navigate(['']);
		}

		this.loginForm = this.fb.group({
			username: ['', [Validators.required]],
			password: ['', [Validators.required]],
		});
	}

	loginData: Login = {
		username: '',
		password: '',
	};

	onSubmit() {
		this.loginData = this.loginForm.value;
		this.authService
			.login(this.loginData)
			.pipe(first())
			.subscribe({
				next: (data) => {
					this.router.navigate(['']);
					localStorage.setItem('loginData', JSON.stringify(data));
				},
				error: (error) => {
					console.log(error);
				},
				complete: () => {},
			});
	}
}
