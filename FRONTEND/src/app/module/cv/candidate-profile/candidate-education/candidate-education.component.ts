import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';

@Component({
	selector: 'app-candidate-education',
	standalone: true,
	imports: [
		MatDividerModule,
		MatButtonModule
	],
	templateUrl: './candidate-education.component.html',
	styleUrl: './candidate-education.component.css'
})
export class CandidateEducationComponent {

}
