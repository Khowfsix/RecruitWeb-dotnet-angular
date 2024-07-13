import { CommonModule } from '@angular/common';
import {
	Component,
	EventEmitter,
	Inject,
	Input,
	OnDestroy,
	OnInit,
	Output,
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../../../core/services/auth.service';
import { Candidate } from '../../../../data/candidate/candidate.model';
import { CandidateService } from '../../../../data/candidate/candidate.service';
import { PersonalDetail } from '../../../../data/candidate/personalDetail';
import { PDEditDialogComponent } from './pd-edit-dialog/pd-edit-dialog.component';
import { WebUser } from '../../../../data/authentication/web-user.model';

@Component({
	selector: 'app-personal-detail',
	standalone: true,
	imports: [
		CommonModule,

		MatDividerModule,
		MatButtonModule,
		NgbTooltipModule,
	],
	templateUrl: './personal-detail.component.html',
	styleUrl: './personal-detail.component.css',
})
export class PersonalDetailComponent implements OnInit, OnDestroy {
	@Input() candidate?: Candidate;
	@Input() user?: WebUser;
	@Output() refresh = new EventEmitter<void>();

	ngOnInit(): void {}

	ngOnDestroy(): void {}

	constructor(
		@Inject(MatDialog) public dialog: MatDialog,
		private _candidateService: CandidateService,
		private _authService: AuthService,
	) {}

	openDialog(): void {
		const dialogRef = this.dialog.open(PDEditDialogComponent, {
			data: this.candidate,
		});
		dialogRef.afterClosed().subscribe((result: PersonalDetail) => {
			if (result) {
				const userId = this._authService.getLocalCurrentUser().id;
				this._candidateService
					.updatePersonalDetail(userId as string, result)
					.subscribe(() => {
						this._authService.updateUserLogin();
						this.refresh.emit();
					});
			}
		});
	}
}
