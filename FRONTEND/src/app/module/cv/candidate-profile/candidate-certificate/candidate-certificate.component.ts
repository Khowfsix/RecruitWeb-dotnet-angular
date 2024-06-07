import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Candidate } from '../../../../data/candidate/candidate.model';

@Component({
	selector: 'app-candidate-certificate',
	standalone: true,
	imports: [],
	templateUrl: './candidate-certificate.component.html',
	styleUrl: './candidate-certificate.component.css'
})
export class CandidateCertificateComponent {
	@Input() candidate?: Candidate;
	@Output() refresh = new EventEmitter<void>();
}
