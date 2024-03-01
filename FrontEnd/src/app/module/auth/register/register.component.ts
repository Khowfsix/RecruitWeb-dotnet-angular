import { Component } from '@angular/core';
import { Register } from '../../../data/authen/register.model';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
	selector: 'app-register',
	standalone: true,
	imports: [],
	templateUrl: './register.component.html',
	styleUrl: './register.component.scss',
})
export class RegisterComponent {
	registerData: Register = {
		fullname: '',
		username: '',
		email: '',
		password: '',
	};

	constructor(private router: Router, private authService: AuthService) {}

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
