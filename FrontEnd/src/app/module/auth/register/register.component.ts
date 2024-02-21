import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

@Component({
	selector: 'app-register',
	standalone: true,
	imports: [MatCardModule, MatFormFieldModule, MatButtonModule],
	templateUrl: './register.component.html',
	styleUrl: './register.component.scss',
})
export class RegisterComponent {}
