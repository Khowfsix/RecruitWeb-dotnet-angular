import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { PDEditDialogComponent } from './pd-edit-dialog/pd-edit-dialog.component';

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
	ngOnInit(): void { }

	ngOnDestroy(): void { }

	constructor(public dialog: MatDialog) { }

	openDialog(): void {
		const dialogRef = this.dialog.open(PDEditDialogComponent, {
			width: '350px',
		});
		dialogRef.afterClosed().subscribe(
			result => {
				console.log(result);
			},
		);
	}
}
