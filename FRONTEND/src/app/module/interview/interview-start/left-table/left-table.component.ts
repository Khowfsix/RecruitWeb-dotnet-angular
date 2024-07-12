/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { ViewDialogComponent } from '../../interview-id/question-table/view-dialog/view-dialog.component';

@Component({
	selector: 'app-left-table',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,

		ViewDialogComponent,

		MatTabsModule,
		MatTableModule,
		MatRadioModule,
	],
	templateUrl: './left-table.component.html',
	styleUrl: './left-table.component.scss',
})
export class LeftTableComponent {
	@Input() leftTable: any;
	@Input() cate?: number;
	@Input() currentQues?: number[];
	// @Output() currentQuesChange = new EventEmitter<number[]>();
	// @Input() currentSubTab?: number;
	// @Output() currentSubTabChange = new EventEmitter<number>();

	// @Output() questionSelected = new EventEmitter<any>();
	selectedQuestion: any = null;

	superSet?: any[];
	columns = [
		{ field: 'questionid', header: 'ID' },
		{ field: 'questionstring', header: 'Suggest question' },
		// { field: 'action', header: 'View' },
	];

	public getFields() {
		return this.columns.map((c) => c.field);
	}

	ngOnInit() {
		this.initializeSuperSet();
	}

	initializeSuperSet() {
		if (this.cate === 0) {
			this.superSet = this.leftTable ? [this.leftTable] : [];
		} else if (this.cate === 1) {
			this.superSet = this.leftTable!.languages
				? this.leftTable!.languages
				: [];
		} else if (this.cate === 2) {
			this.superSet = this.leftTable.skills ? this.leftTable.skills : [];
		}
	}

	// onTabChange(index: number) {
	// 	this.currentQuesChange.emit([]);
	// 	this.currentSubTabChange.emit(index);
	// }

	chosenQues: any;
	// onSelectionChange(event: any) {
	// 	this.currentQuesChange.emit(event);
	// }

	getTabLabel(sub: any): string {
		if (this.cate === 0) return 'SOFT SKILL';
		if (this.cate === 1) return sub.languagename;
		if (this.cate === 2) return sub.skillname;
		return '';
	}

	// onRowClick(question: any) {
	// 	this.selectedQuestion = question;
	// 	console.log(this.selectedQuestion);
	// 	this.questionSelected.emit(question);
	// }

	// isSelected(question: any): boolean {
	// 	return this.selectedQuestion === question;
	// }
}
