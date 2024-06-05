/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-delete-dialog',
	standalone: true,
	imports: [
		MatButtonModule,
		MatDialogActions,
		MatDialogClose,
		MatDialogTitle,
		MatDialogContent,
	],
	templateUrl: './delete-dialog.component.html',
	styleUrl: './delete-dialog.component.css'
})
export class DeleteDialogComponent {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		public dialogRef: MatDialogRef<DeleteDialogComponent>,
		private toastr: ToastrService,
	) { }

	public objectLabel: string = this.data.objectLabel ?? undefined;
	public objectName: string = this.data.objectName ?? undefined;
	private deleteApiServiceObservable: any = this.data.deleteApiServiceObservable ?? undefined;

	public deleteSubmit() {
		this.deleteApiServiceObservable.subscribe({
			next: () => { },
			error: () => {
				this.toastr.error('Something wrong...', 'Error!!!', { toastClass: ' my-custom-toast ngx-toastr', });
			},
			complete: () => {
				this.dialogRef.close();
				this.toastr.success(this.objectLabel + ' Deleted...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 2000,
				});
			},
		});
	}
}
