import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { PDEditDialogComponent } from './pd-edit-dialog/pd-edit-dialog.component';
import { CandidateService } from '../../../../data/candidate/candidate.service';
import { AuthService } from '../../../../core/services/auth.service';
import { Candidate } from '../../../../data/candidate/candidate.model';

@Component({
	selector: 'app-personal-detail',
	standalone: true,
	imports: [
		MatDividerModule,
		MatButtonModule,
		NgbTooltipModule
	],
	templateUrl: './personal-detail.component.html',
	styleUrl: './personal-detail.component.css',
})
export class PersonalDetailComponent implements OnInit, OnDestroy {
	@Input() candidate: Candidate = new Candidate();

	ngOnInit(): void { }

	ngOnDestroy(): void { }

	constructor(
		public dialog: MatDialog,
		private _candidateService: CandidateService,
		private _authService: AuthService
	) {
		console.log(this.candidate);
	}

	openDialog(): void {
		const dialogRef = this.dialog.open(PDEditDialogComponent, {
			data: this.candidate
		});
		dialogRef.afterClosed().subscribe(
			result => {
				console.log(result);
			},
		);
	}
}
