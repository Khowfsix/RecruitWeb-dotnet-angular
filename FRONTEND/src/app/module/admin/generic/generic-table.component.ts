import { ChangeDetectorRef, Component, Inject, Input, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CommonModule, DecimalPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { BehaviorSubject, Subscription } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';

@Component({
	selector: 'app-generic-table',
	standalone: true,
	imports: [
		MatFormFieldModule,
		MatInputModule,
		MatTableModule,
		MatSortModule,
		MatPaginatorModule,
		MatButtonModule,
		MatIconModule,

		NgbTypeaheadModule,
		NgbPaginationModule,

		FormsModule,
		DecimalPipe,
		CommonModule
	],
	templateUrl: './generic-table.component.html',
	styleUrls: ['./generic-table.component.css'],
})
export class GenericTableComponent {
	@Input() dataInput = new BehaviorSubject<any[]>([]);
	@Input() listProps: string[] = [];
	@Input() displayedColumns: string[] = [];

	@Input() createData: (data: any) => void = (data: any) => { };
	@Input() editData = () => { };
	@Input() deleteData: (data: any) => void = (data: any) => { };


	dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
	private dataInputSubscription: Subscription = new Subscription();

	@ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(this._intl, this._changeDetectorRef);
	@ViewChild(MatSort) sort: MatSort = new MatSort();

	constructor(
		public dialog: MatDialog,
		private _intl: MatPaginatorIntl,
		private _changeDetectorRef: ChangeDetectorRef
	) {
		console.log(this.deleteData);
	}

	ngOnInit() {
		// Subscribe to the BehaviorSubject to get the latest data
		this.dataInputSubscription = this.dataInput.subscribe(data => {
			this.dataSource.data = data;
			// Make sure paginator and sorting are applied
			this.dataSource.paginator = this.paginator;
			this.dataSource.sort = this.sort;
		});

		this.displayedColumns = [...this.displayedColumns, 'action'];
	}

	ngOnDestroy() {
		// Unsubscribe to avoid memory leaks
		if (this.dataInputSubscription) {
			this.dataInputSubscription.unsubscribe();
		}
	}

	ngAfterViewInit() {
		this.dataSource.paginator = this.paginator;
		this.dataSource.sort = this.sort;
	}

	applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.dataSource.filter = filterValue.trim().toLowerCase();

		if (this.dataSource.paginator) {
			this.dataSource.paginator.firstPage();
		}
	}


	create(): void {
		// const dialogRef = this.dialog.open(GenericCreateDialogComponent, {

		// });

		// dialogRef.afterClosed().subscribe(result => {
		// 	if (result) {
		// 		// Thực hiện hành động sau khi form dialog đóng
		// 		this.createData?.(result);
		// 	}
		// });
	}

	edit(entity: any): void {
		// this.openDialog(entity);
	}

	delete(data: any): void {
		const confirmDialogRef = this.dialog.open(AdminDeleteConfirmDialogComponent, {
			data: { title: 'Confirm Delete', message: `Are you sure you want to delete this record?` }
		});

		confirmDialogRef.afterClosed().subscribe(result => {
			if (result === true) {
				// Tiến hành xóa entity
				// Ví dụ: gọi service để xóa entity từ database
				console.log(data);
				this.deleteData?.(data);
			}
		});
	}
}


@Component({
	standalone: true,
	selector: 'app-admin-delete-dialog',
	imports: [
		CommonModule,
		MatDialogModule,
		MatButtonModule
	],
	template: `
	<h1 mat-dialog-title>{{ data.title }}</h1>
	<div mat-dialog-content>
		<p>{{ data.message }}</p>
	</div>
	<div mat-dialog-actions class="d-flex justify-content-end">
		<button mat-button color="primary" (click)="onDismiss()">Cancel</button>
		<button mat-button color="warn" [mat-dialog-close]="true" cdkFocusInitial>Okay</button>
	</div>
	`,
})
export class AdminDeleteConfirmDialogComponent {
	constructor(
		public dialogRef: MatDialogRef<AdminDeleteConfirmDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
	) { }

	onDismiss(): void {
		this.dialogRef.close(false);
	}
}
