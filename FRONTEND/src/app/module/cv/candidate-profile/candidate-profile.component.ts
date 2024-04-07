import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { NgbProgressbarModule, NgbScrollSpyModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-candidate-profile',
	standalone: true,
	imports: [
		MatDividerModule,
		MatButtonModule,
		NgbProgressbarModule,
		NgbScrollSpyModule
	],
	templateUrl: './candidate-profile.component.html',
	styleUrl: './candidate-profile.component.css'
})
export class CandidateProfileComponent { }
