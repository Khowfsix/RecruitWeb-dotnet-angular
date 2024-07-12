/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, Input, ViewChild } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
	selector: 'app-two-table',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		MatTableModule,
		MatFormFieldModule,
		MatButtonModule,
		MatIconModule,
		MatPaginatorModule,
	],
	templateUrl: './two-table.component.html',
	styleUrls: ['./two-table.component.css'],
})
export class TwoTableComponent {
	leftColumns: string[] = ['Question', 'action'];
	rightColumns: string[] = ['Question', 'action'];

	leftDataSource: MatTableDataSource<any>;
	rightDataSource: MatTableDataSource<any>;

	@Input() leftList: any[] = [];
	@Input() rightList: any[] = [];

	filter: FormControl = new FormControl('');

	@ViewChild(MatPaginator, { static: true }) paginator?: MatPaginator;

	constructor() {
		this.leftDataSource = new MatTableDataSource(this.leftList);
		this.rightDataSource = new MatTableDataSource(this.rightList);
	}

	ngOnInit(): void {
		this.leftDataSource.paginator = this.paginator!; // If using a paginator
		this.rightDataSource.paginator = this.paginator!; // If using a paginator
	}

	applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.leftDataSource.filter = filterValue.trim().toLowerCase();
	}

	addToRight(element: any) {
		this.rightDataSource.data = [...this.rightDataSource.data, element];
		this.leftDataSource.data = this.leftDataSource.data.filter(
			(item) => item !== element,
		);
	}

	addToLeft(element: any) {
		this.leftDataSource.data = [...this.leftDataSource.data, element];
		this.rightDataSource.data = this.rightDataSource.data.filter(
			(item) => item !== element,
		);
	}
}
