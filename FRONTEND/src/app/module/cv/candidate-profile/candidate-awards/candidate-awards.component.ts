import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Candidate } from '../../../../data/candidate/candidate.model';

@Component({
	selector: 'app-candidate-awards',
	standalone: true,
	imports: [],
	templateUrl: './candidate-awards.component.html',
	styleUrl: './candidate-awards.component.css'
})
export class CandidateAwardsComponent {
	@Input() candidate?: Candidate;
	@Output() refresh = new EventEmitter<void>();
}
