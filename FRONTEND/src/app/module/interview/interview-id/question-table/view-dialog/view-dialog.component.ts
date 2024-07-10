/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatChipsModule } from '@angular/material/chips';
import { ThemePalette } from '@angular/material/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';

@Component({
	selector: 'app-view-dialog',
	standalone: true,
	imports: [
		MatIconModule
	],
	template: `
		<button mat-icon-button (click)="openDialog()">
			<mat-icon>visibility</mat-icon>
		</button>
	`
})
export class ViewDialogComponent {
	@Input() params: any;
	@Input() cate?: number;
	@Input() skillname?: string;
	@Input() languagename?: string;

	constructor(public dialog: MatDialog) { }

	openDialog(): void {
		this.dialog.open(ViewDialogContentComponent, {
			data: {
				params: this.params,
				cate: this.cate,
				skillname: this.skillname,
				languagename: this.languagename
			}
		});
	}
}

@Component({
	standalone: true,
	selector: 'app-view-dialog-content',
	templateUrl: 'view-dialog-content.component.html',
	imports: [
		MatDialogModule,
		MatIconModule,
		MatFormFieldModule,
		MatChipsModule,

		FormsModule,
		ReactiveFormsModule,
		CommonModule
	]
})
export class ViewDialogContentComponent implements OnInit {
	categoryName?: string;
	categoryIcon?: string;
	chipColor: ThemePalette;

	constructor(
		public dialogRef: MatDialogRef<ViewDialogContentComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
	) { }

	ngOnInit(): void {
		this.setCategoryInfo();
	}

	setCategoryInfo(): void {
		if (this.data.cate === 0) {
			this.categoryName = 'Soft Skills';
			this.categoryIcon = 'handshake';
			this.chipColor = 'accent';
		} else if (this.data.cate === 1) {
			this.categoryName = 'Language';
			this.categoryIcon = 'language';
			this.chipColor = 'primary';
		} else if (this.data.cate === 2) {
			this.categoryName = 'Technology';
			this.categoryIcon = 'tungsten';
			this.chipColor = 'warn';
		}
	}
}
