import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
	selector: 'app-profile',
	standalone: true,
	imports: [MatCardModule],
	templateUrl: './profile.component.html',
	styleUrl: './profile.component.scss',
})
export class ProfileComponent { }
