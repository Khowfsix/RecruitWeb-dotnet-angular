import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { Candidate } from '../../../../data/candidate/candidate.model';

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
	@Input() candidate?: Candidate;
	@Output() refresh = new EventEmitter<void>();
}
