import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';

@Component({
	selector: 'app-logout-dialog',
	standalone: true,
	imports: [MatDialogModule, MatButtonModule],
	templateUrl: './logout-dialog.component.html',
})
export class LogoutDialogComponent {
	constructor(
		public dialogRef: MatDialogRef<LogoutDialogComponent>,
	) { }

	onNoClick(): void {
		this.dialogRef.close();
	}

	onLogoutClick(): void {
		this.dialogRef.close(true);
	}
}
