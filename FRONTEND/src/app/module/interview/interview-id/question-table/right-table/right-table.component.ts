/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import {
	ChangeDetectorRef,
	Component,
	EventEmitter,
	Input,
	NgZone,
	Output,
	SimpleChanges,
} from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { BehaviorSubject } from 'rxjs';
import { QuestionService } from '../../../../../data/question/question.service';
import { ViewDialogComponent } from '../view-dialog/view-dialog.component';

@Component({
	selector: 'app-right-table',
	standalone: true,
	imports: [
		MatTabsModule,
		MatTableModule,
		MatFormFieldModule,
		MatInputModule,

		ViewDialogComponent,

		CommonModule,
		FormsModule,
		ReactiveFormsModule,
	],
	templateUrl: './right-table.component.html',
})
export class RightTableComponent {
	private tableData = new BehaviorSubject<any[]>([]);
	data$ = this.tableData.asObservable();

	@Input() set rightTable(value: any) {
		this.tableData.next(value);
	}
	@Input() cate?: number;
	@Input() currentSubTab?: number;
	// @Input() setCurrentQues: any;
	@Output() currentSubTabChange = new EventEmitter<number>();

	scoreControl = new FormControl();

	displayedColumns: string[] = ['questionstring', 'score'];
	tabComponents: any[] = [];
	superSet: any[] = [];

	constructor(
		private questionService: QuestionService,
		private cdr: ChangeDetectorRef,
		private zone: NgZone,
	) {}

	ngOnInit() {
		this.initializeComponent();
	}

	ngOnChanges(changes: SimpleChanges) {
		if (changes['rightTable'] && !changes['rightTable'].firstChange) {
			console.log('Previous:', changes['rightTable'].previousValue);
			console.log('Current:', changes['rightTable'].currentValue);
			this.zone.run(() => {
				this.initializeComponent();
				this.cdr.detectChanges();
			});
			console.log(this.rightTable);
		}
	}

	refresh(): void {
		// this.data$;
	}

	initializeComponent() {
		if (this.rightTable) {
			console.log(this.rightTable);
			// Additional UI update logic can be placed here,
			// for example, to refresh data displayed in the component
			if (this.cate === 0) {
				this.tabComponents = [{ label: 'Soft Skill' }];
				this.superSet = [this.rightTable];
				// this.superSet = [this.rightTable];
			} else if (this.cate === 1) {
				if (this.rightTable.languages) {
					this.tabComponents = this.rightTable.languages.map(
						(lang: { languagename: any }) => ({
							label: lang.languagename,
						}),
					);
					this.superSet = this.rightTable.languages;
				}
			} else if (this.cate === 2) {
				if (this.rightTable.skills) {
					this.tabComponents = this.rightTable.skills.map(
						(skill: { skillname: any }) => ({
							label: skill.skillname,
						}),
					);
					this.superSet = this.rightTable.skills;
				}
			}

			this.tableData.next(this.superSet);
			this.cdr.markForCheck();
		}
	}

	onTabChange(index: number) {
		// if (this.setCurrentQues) {
		// 	this.setCurrentQues([]);
		// }
		this.currentSubTabChange.emit(index);
	}

	onScoreChange(element: any) {
		// const newQues = {
		// 	categoryOrder: this.cate,
		// 	subOrder: this.currentSubTab,
		// 	chosenQuestionId: element.questionid,
		// 	newScore:
		// 		element.score >= 0 && element.score <= 10 ? element.score : '',
		// };

		console.log(element);
		// this.questionService
		// 	.scoreQuestion(newQues as NewQuestion)
		// 	.subscribe((response) => {
		// 		console.log('Question scored successfully', response);
		// 		// Thực hiện các hành động cần thiết sau khi chuyển câu hỏi
		// 	});
	}
}
