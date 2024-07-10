/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
	selector: 'app-question-data-grid',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		MatFormFieldModule,
		MatTableModule,
		MatPaginatorModule,
		MatIconModule,
		MatButtonModule
	],
	templateUrl: './question-data-grid.component.html',
	styleUrl: './question-data-grid.component.css'
})
export class QuestionDataGridComponent {
	@Input() set rows(data: any[]) {
		this.dataSource.data = data;
	}

	@Output() editQuestion = new EventEmitter<any>();
	@Output() deleteQuestion = new EventEmitter<any>();

	@ViewChild(MatPaginator) paginator!: MatPaginator;
	@ViewChild(MatSort) sort!: MatSort;

	dataSource: MatTableDataSource<any> = new MatTableDataSource();
	displayedColumns: string[] = ['QuestionId', 'QuestionName', 'CategoryName', 'TypeName', 'actions'];

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

	onRowClick(row: any) {
		this.editQuestion.emit({
			QuestionId: row.QuestionId,
			QuestionName: row.QuestionName,
			CategoryId: row.CategoryId,
			CategoryName: row.CategoryName,
			TypeId: row.TypeId,
			TypeName: row.TypeName,
		});
	}

	onEditClick(row: any) {
		this.editQuestion.emit({
			QuestionId: row.QuestionId,
			QuestionName: row.QuestionName,
			CategoryId: row.CategoryId,
			CategoryName: row.CategoryName,
			TypeId: row.TypeId,
			TypeName: row.TypeName,
		});
	}

	onDeleteClick(row: any) {
		this.deleteQuestion.emit({
			QuestionId: row.QuestionId,
			CategoryId: row.CategoryId,
		});
	}
}
