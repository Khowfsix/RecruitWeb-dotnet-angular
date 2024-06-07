import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Candidate } from '../../../../data/candidate/candidate.model';

@Component({
	selector: 'app-personal-project',
	standalone: true,
	imports: [],
	templateUrl: './personal-project.component.html',
	styleUrl: './personal-project.component.css'
})
export class PersonalProjectComponent {
	@Input() candidate?: Candidate;
	@Output() refresh = new EventEmitter<void>();
}
