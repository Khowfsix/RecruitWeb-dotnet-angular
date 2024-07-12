import { CommonModule } from '@angular/common';
import { Component, Inject, Injectable } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';

@Component({
	selector: 'app-alert-dialog',
	standalone: true,
	imports: [
		MatDialogModule,
		MatButtonModule,
		MatIconModule,
		CommonModule
	],
	templateUrl: './alert-dialog.component.html',
	styleUrl: './alert-dialog.component.css'
})
export class AlertDialogComponent {
	constructor(
		public dialogRef: MatDialogRef<AlertDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: { message: string }
	) { }
}

@Injectable({
	providedIn: 'root'
})
export class AlertDialogService {
	constructor(private dialog: MatDialog) { }

	openDialog(message: string): Observable<boolean> {
		const dialogRef = this.dialog.open(AlertDialogComponent, {
			width: '400px',
			data: { message }
		});

		return dialogRef.afterClosed();
	}
}
