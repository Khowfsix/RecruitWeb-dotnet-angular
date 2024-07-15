import { Component, OnDestroy, OnInit } from '@angular/core';
import { Register } from '../../../data/authen/register.model';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import {
	AbstractControl,
	AsyncValidatorFn,
	FormBuilder,
	FormControl,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
	ValidationErrors,
	Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { debounceTime, map, Observable, of, switchMap, timer } from 'rxjs';
import { MatError, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
	selector: 'app-register',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		MatFormFieldModule,
		MatInputModule,
		MatError,
		MatIconModule,
		MatButtonModule,
	],
	templateUrl: './register.component.html',
	styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit, OnDestroy {
	registerForm: FormGroup;
	private readonly debounceTimeMs = 300; // Set the debounce time (in milliseconds)
	processValue = 50;
	isProcess = true;

	hide1 = true;
	hide2 = true;

	constructor(
		private router: Router,
		private authService: AuthService,
		private _formBuilder: FormBuilder,
		private toastr: ToastrService,
	) {
		this.registerForm = this._formBuilder.group(
			{
				fullname: new FormControl('', {
					validators: [
						Validators.required,
						Validators.pattern('[a-zA-Z0-9]*'),
						Validators.minLength(4),
					],
				}),
				username: new FormControl('', {
					validators: [
						Validators.required,
						Validators.pattern('[a-zA-Z0-9]*'),
						Validators.minLength(2),
					],
					asyncValidators: [this.userNameNotExistValidator()],
					updateOn: 'change',
				}),
				email: new FormControl('', {
					validators: [Validators.required, Validators.email],
					asyncValidators: [this.emailNotExistValidator()],
					updateOn: 'change',
				}),
				password: new FormControl('', {
					validators: [
						Validators.required,
						Validators.minLength(8),
						Validators.pattern(
							'(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\\W]).*',
						),
					],
				}),
				confirmPassword: new FormControl('', {
					validators: [Validators.required],
				}),
			},
			{ validator: this.MustMatch('password', 'confirmPassword') },
		);
	}

	ngOnInit(): void {}

	ngOnDestroy(): void {}

	checkValidUsername(username: string) {
		return this.authService.isValidUsername(username);
	}

	checkValidEmail(email: string) {
		return this.authService.isValidEmail(email);
	}

	onSubmit() {
		if (!this.registerForm.valid) {
			this.registerForm.markAllAsTouched(); // clear
			this.toastr.error(
				'Please fill in all the required fields',
				'Error',
				{
					toastClass: ' my-custom-toast ngx-toastr',
				},
			);
			return;
		}

		const payload: Register = {
			fullname: this.registerForm.value.fullname,
			username: this.registerForm.value.username,
			email: this.registerForm.value.email,
			password: this.registerForm.value.password,
		};

		this.authService.register(payload).subscribe({
			next: (data: unknown) => {
				console.log(data);
			},
			error: (error: unknown) => {
				console.log(error);
			},
			complete: () => {
				this.toastr.success('Registration successful', 'Success', {
					toastClass: ' my-custom-toast ngx-toastr',
				});
				this.router.navigate(['/auth/confirm-email']);
			},
		});
	}

	// repeat password input match with password
	MustMatch(controlName: string, matchingControlName: string) {
		return (formGroup: FormGroup) => {
			const control = formGroup.controls[controlName];
			const matchingControl = formGroup.controls[matchingControlName];

			if (control.value !== matchingControl.value) {
				matchingControl.setErrors({ mustMatch: true });
			} else {
				matchingControl.setErrors(null);
			}
		};
	}

	userNameNotExistValidator(): AsyncValidatorFn {
		return (
			control: AbstractControl,
		): Observable<ValidationErrors | null> => {
			return timer(300) // Delay 300ms
				.pipe(
					switchMap(() => {
						if (!control.value) {
							return of(null); // Nếu không có value, không cần kiểm tra
						}
						return this.checkValidUsername(control.value).pipe(
							map((valid) =>
								!valid ? { userNameExist: true } : null,
							),
						);
					}),
					debounceTime(300), // Debounce thêm để đảm bảo không gửi request nếu giá trị control thay đổi liên tục
				);
		};
	}

	emailNotExistValidator(): AsyncValidatorFn {
		return (
			control: AbstractControl,
		): Observable<ValidationErrors | null> => {
			return timer(300) // Delay 300ms
				.pipe(
					switchMap(() => {
						if (!control.value) {
							return of(null); // Nếu không có value, không cần kiểm tra
						}
						return this.checkValidEmail(control.value).pipe(
							map((valid) =>
								!valid ? { emailExist: true } : null,
							),
						);
					}),
					debounceTime(300), // Debounce thêm để đảm bảo không gửi request nếu giá trị control thay đổi liên tục
				);
		};
	}
}
