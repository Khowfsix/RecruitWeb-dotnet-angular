import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';

@Component({
	standalone: true,
	selector: 'app-generic-create-dialog',
	imports: [
		MatDialogModule,
		MatButtonModule,
	],
	template: `
	<h1 mat-dialog-title>Create Record</h1>
	<div mat-dialog-content>
	</div>
	<div mat-dialog-actions>
		<!-- @for (item of items; track $index) {

		} -->
		<div class="d-flex justify-content-end">
			<button mat-button color="warn" (click)="onCancel()">Cancel</button>
			<button mat-button color="primary" [mat-dialog-close]="data" cdkFocusInitial>Save</button>
		</div>
	</div>`,
})
export class GenericCreateDialogComponent {
	constructor(
		public dialogRef: MatDialogRef<GenericCreateDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
	) { }

	onCancel(): void {
		this.dialogRef.close();
	}
}
