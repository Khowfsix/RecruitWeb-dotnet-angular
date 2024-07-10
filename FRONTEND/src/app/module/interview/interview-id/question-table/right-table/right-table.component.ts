/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { Store } from '@ngrx/store';
import { ViewDialogComponent } from '../view-dialog/view-dialog.component';
import { CommonModule } from '@angular/common';

@Component({
	selector: 'app-right-table',
	standalone: true,
	imports: [
		MatTabsModule,
		MatTableModule,
		MatFormFieldModule,

		ViewDialogComponent,

		FormsModule,
		CommonModule,
	],
	templateUrl: './right-table.component.html',
})
export class RightTableComponent {
	@Input() rightTable: any;
	@Input() cate?: number;
	@Input() currentSubTab?: number;
	@Input() setCurrentQues: any;
	@Output() currentSubTabChange = new EventEmitter<number>();

	displayedColumns: string[] = ['questionid', 'questionstring', 'action', 'score'];
	tabComponents: any[] = [];
	superSet: any[] = [];

	constructor(private store: Store) { }

	ngOnInit() {
		this.initializeComponent();
	}

	initializeComponent() {
		if (this.cate === 0) {
			this.tabComponents = [{ label: "Soft Skill" }];
			this.superSet = [this.rightTable];
		} else if (this.cate === 1) {
			this.tabComponents = this.rightTable.languages.map((lang: { languagename: any; }) => ({ label: lang.languagename }));
			this.superSet = this.rightTable.languages;
		} else if (this.cate === 2) {
			this.tabComponents = this.rightTable.skills.map((skill: { skillname: any; }) => ({ label: skill.skillname }));
			this.superSet = this.rightTable.skills;
		}
	}

	onTabChange(index: number) {
		if (this.setCurrentQues) {
			this.setCurrentQues([]);
		}
		this.currentSubTabChange.emit(index);
	}

	onScoreChange(element: any) {
		const newQues = {
			categoryOrder: this.cate,
			subOrder: this.currentSubTab,
			chosenQuestionId: element.questionid,
			newScore: element.score >= 0 && element.score <= 10 ? element.score : ""
		};
		this.store.dispatch({ type: "question/scoreQuestion", payload: newQues });
	}
}
