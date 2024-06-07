import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';
import { Candidate } from '../../../../data/candidate/candidate.model';

@Component({
	selector: 'app-work-experience',
	standalone: true,
	imports: [MatDividerModule],
	templateUrl: './work-experience.component.html',
	styleUrl: './work-experience.component.css'
})
export class WorkExperienceComponent {
	@Input() candidate?: Candidate;
	@Output() refresh = new EventEmitter<void>();
}
