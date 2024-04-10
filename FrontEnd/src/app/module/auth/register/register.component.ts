import { Component, OnDestroy, OnInit } from '@angular/core';
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
import { debounceTime, Subject } from 'rxjs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
	selector: 'app-register',
	standalone: true,
	imports: [
		FormsModule,
		ReactiveFormsModule,
		MatFormFieldModule,
		MatInputModule,
	],
	templateUrl: './register.component.html',
	styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit, OnDestroy {
	registerForm: FormGroup;
	registerData = new Subject<Register>();
	private readonly debounceTimeMs = 300; // Set the debounce time (in milliseconds)
	processValue = 50;
	isProcess = true;

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

	ngOnInit(): void {

	}

	ngOnDestroy(): void {

	}

	checkValidUsername(username: string): boolean {
		this.authService
			.isValidUsername(username)
			.subscribe({
				next: (data) => {
					console.log(data);
					return data as boolean;
				},
				error: (error) => {
					console.log(error);
					return false;
				},
			});
		return true;
	}

	checkValidEmail(email: string): boolean {
		this.authService
			.isValidEmail(email)
			.subscribe({
				next: (data) => {
					console.log(data);
					return data as boolean;
				},
				error: (error) => {
					console.log(error);
					return false;
				},
			});
		return true;
	}

	onSubmit() {
		this.registerData.next(this.registerForm.value)
		this.registerData.subscribe({
			next: (data) => {
				console.log(`Register data: ${JSON.stringify(this.registerData)}`);
				this.authService.register(data).subscribe({
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
		});
	}

	// repeat password input match with password
	passwordMatchValidator(fg: FormGroup) {
		return fg.get('password')?.value === fg.get('confirmPassword')?.value
			? null
			: { mismatch: true };
	}

	onCheckValidUsername() {
		this.registerData.next(this.registerForm.value);
		this.registerData.pipe(debounceTime(this.debounceTimeMs))
			.subscribe({
				next: (object) => {
					return this.checkValidUsername(object.username);
				},
				error: () => { return false; },
			});
		return true;
	}

	onCheckValidEmail() {
		this.registerData.next(this.registerForm.value);
		this.registerData.pipe(debounceTime(this.debounceTimeMs))
			.subscribe({
				next: (object) => {
					return this.checkValidEmail(object.email);
				},
				error: () => { return false; },
			});
		return true;
	}
}
