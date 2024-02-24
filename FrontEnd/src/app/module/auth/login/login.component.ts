import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIcon } from '@angular/material/icon';

@Component({
	selector: 'app-login',
	standalone: true,
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss',
	imports: [MatCardModule, MatFormFieldModule, MatIcon, MatGridListModule],
})
export class LoginComponent {
	hide: boolean = true;
}
