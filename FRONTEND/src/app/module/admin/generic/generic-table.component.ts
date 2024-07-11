/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @typescript-eslint/no-unused-vars */
import { ChangeDetectorRef, Component, Inject, Input, SimpleChanges, ViewChild, ViewContainerRef } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
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
import { GenericCreateDialogComponent } from './generic-dialog.component';
import { MatExpansionModule } from '@angular/material/expansion';


export type ActionType = 'create' | 'read' | 'update' | 'delete' | 'accept' | 'deny';


@Component({
	selector: 'app-generic-table',
	standalone: true,
	imports: [
		MatExpansionModule,
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
	animations: [
		trigger('detailExpand', [
			state('collapsed,void', style({ height: '0px', minHeight: '0' })),
			state('expanded', style({ height: '*' })),
			transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
		]),
	],
	templateUrl: './generic-table.component.html',
	styleUrls: ['./generic-table.component.css'],
})

export class GenericTableComponent {
	@Input() actions: ActionType[] | undefined = undefined;
	@Input() dataInput = new BehaviorSubject<any[]>([]);
	@Input() listProps: string[] = [];
	@Input() displayedColumns: string[] = [];
	@Input() detailListProps: string[] = [];
	@Input() detailDisplayedColumns: string[] = [];

	public columnsToDisplayWithExpand: string[] = [];
	public expandedElement: any | null;

	@Input() createData: () => void = () => { };
	@Input() editData: (data: any) => void = (data: any) => { };
	@Input() deleteData: (data: any) => void = (data: any) => { };
	@Input() acceptData: (data: any) => void = (data: any) => { };
	@Input() denyData: (data: any) => void = (data: any) => { };

	public dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
	private dataInputSubscription: Subscription = new Subscription();

	@ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(this._intl, this._changeDetectorRef);
	@ViewChild(MatSort) sort: MatSort = new MatSort();

	constructor(
		private viewContainerRef: ViewContainerRef,
		public dialog: MatDialog,
		private _intl: MatPaginatorIntl,
		private _changeDetectorRef: ChangeDetectorRef
	) { }

	ngOnChanges(changes: SimpleChanges) {
		if (changes['displayedColumns']) {
			this.columnsToDisplayWithExpand = [...changes['displayedColumns'].currentValue, 'action']
		}
	}

	ngOnInit() {
		this.columnsToDisplayWithExpand = [...this.displayedColumns, 'action'];
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

	delete(data: any): void {
		const confirmDialogRef = this.dialog.open(ConfirmDialogComponent, {
			data: { title: 'Confirm Delete', message: `Are you sure you want to delete this record?` }
		});

		confirmDialogRef.afterClosed().subscribe(result => {
			if (result === true) {
				// Tiến hành xóa entity
				// Ví dụ: gọi service để xóa entity từ database
				// console.log(data);
				this.deleteData?.(data);
			}
		});
	}

	accept(data: any): void {
		const confirmDialogRef = this.dialog.open(ConfirmDialogComponent, {
			data: { title: 'Accept', message: `Are you sure you want to accept this record?` }
		});

		confirmDialogRef.afterClosed().subscribe(result => {
			if (result === true) {
				this.acceptData?.(data);
			}
		});
	}

	deny(data: any): void {
		const confirmDialogRef = this.dialog.open(ConfirmDialogComponent, {
			data: { title: 'Deny', message: `Are you sure you want to deny this record?` }
		});

		confirmDialogRef.afterClosed().subscribe(result => {
			if (result === true) {
				this.denyData?.(data);
			}
		});
	}
}


@Component({
	standalone: true,
	selector: 'app-confirm-dialog',
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
export class ConfirmDialogComponent {
	constructor(
		public dialogRef: MatDialogRef<ConfirmDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
	) { }

	onDismiss(): void {
		this.dialogRef.close(false);
	}
}
