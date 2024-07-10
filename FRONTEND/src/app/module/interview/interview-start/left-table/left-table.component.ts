/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { ViewDialogComponent } from '../../interview-id/question-table/view-dialog/view-dialog.component';
import { MatTableModule } from '@angular/material/table';

@Component({
	selector: 'app-left-table',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,

		ViewDialogComponent,

		MatTabsModule,
		MatTableModule,
	],
	templateUrl: './left-table.component.html',
	styleUrl: './left-table.component.css'
})
export class LeftTableComponent {
	@Input() leftTable: any;
	@Input() cate?: number;
	@Input() currentQues?: number[];
	@Output() currentQuesChange = new EventEmitter<number[]>();
	@Input() currentSubTab?: number;
	@Output() currentSubTabChange = new EventEmitter<number>();

	superSet?: any[];
	columns = [
		{ field: 'questionid', header: 'ID' },
		{ field: 'questionstring', header: 'String' },
		{ field: 'action', header: 'View' }
	];

	ngOnInit() {
		this.initializeSuperSet();
	}

	initializeSuperSet() {
		if (this.cate === 0) {
			this.superSet = [this.leftTable];
		} else if (this.cate === 1) {
			this.superSet = this.leftTable.languages;
		} else if (this.cate === 2) {
			this.superSet = this.leftTable.skills;
		}
	}

	onTabChange(index: number) {
		this.currentQuesChange.emit([]);
		this.currentSubTabChange.emit(index);
	}

	onSelectionChange(event: any) {
		this.currentQuesChange.emit(event);
	}

	getTabLabel(sub: any): string {
		if (this.cate === 0) return 'SOFT SKILL';
		if (this.cate === 1) return sub.languagename;
		if (this.cate === 2) return sub.skillname;
		return '';
	}
}
