import { Component } from '@angular/core';
import { Register } from '../../../data/authen/register.model';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import {
	FormBuilder,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
	Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-register',
	standalone: true,
	imports: [FormsModule, ReactiveFormsModule],
	templateUrl: './register.component.html',
	styleUrl: './register.component.scss',
})
export class RegisterComponent {
	registerForm: FormGroup;
	registerData: Register = {
		fullname: '',
		username: '',
		email: '',
		password: '',
	};

	// repeat password input match with password
	passwordMatchValidator(fg: FormGroup) {
		return fg.get('password')?.value === fg.get('confirmPassword')?.value
			? null
			: { mismatch: true };
	}

	constructor(
		private router: Router,
		private authService: AuthService,
		private fb: FormBuilder,
		private toastr: ToastrService,
	) {
		this.registerForm = this.fb.group(
			{
				fullname: ['', [Validators.required]],
				username: [
					'',
					Validators.required,
					Validators.pattern('[a-zA-Z0-9]*'),
				],
				email: ['', [Validators.required, Validators.email]],
				password: [
					'',
					Validators.required,
					Validators.minLength(8),
					Validators.pattern(
						'(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\\W]).*',
					),
				],
				confirmPassword: [''],
			},
			{ validators: this.passwordMatchValidator },
		);
	}

	onSubmit() {
		this.authService.register(this.registerData).subscribe({
			next: (data: unknown) => {
				console.log(data);
			},
			error: (error: unknown) => {
				console.log(error);
			},
			complete: () => {
				this.router.navigate(['/auth/login']);
			},
		});
	}
}
