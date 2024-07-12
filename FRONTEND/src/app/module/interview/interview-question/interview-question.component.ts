/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { QuestionService } from '../../../data/question/question.service';
import { SkillService } from '../../../data/skill/skill.service';
import { LanguageService } from '../../../data/language/language.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { QuestionDataGridComponent } from './question-data-grid/question-data-grid.component';

@Component({
	selector: 'app-interview-question',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,

		MatCardModule,
		MatButtonModule,
		MatIconModule,
		MatFormFieldModule,
		MatOptionModule,

		QuestionDataGridComponent,
	],
	templateUrl: './interview-question.component.html',
})
export class InterviewQuestionComponent {
	rows: any[] = [];
	valueChoose: string | null = null;
	skillChoose: any = null;
	languageChoose: any = null;
	skills: any[] = [];
	languages: any[] = [];

	constructor(
		private dialog: MatDialog,
		private questionService: QuestionService,
		private skillService: SkillService,
		private languageService: LanguageService,
	) {}

	ngOnInit() {
		this.getAllQuestions();
		this.getSkills();
		this.getLanguages();
	}

	getAllQuestions() {
		// this.loading = true;
		// this.questionService.getAllQuestions().subscribe(
		// 	(data) => {
		// 		this.rows = data;
		// 		this.loading = false;
		// 	},
		// 	(error) => {
		// 		console.error('Error fetching questions:', error);
		// 		this.loading = false;
		// 	}
		// );
	}

	getSkills() {
		this.skillService.getAllSkills().subscribe(
			(data) => {
				this.skills = data;
			},
			(error) => {
				console.error('Error fetching skills:', error);
			},
		);
	}

	getLanguages() {
		this.languageService.getAllLanguagues().subscribe(
			(data) => {
				this.languages = data;
			},
			(error) => {
				console.error('Error fetching languages:', error);
			},
		);
	}

	handleChooseValue(value: string) {
		this.valueChoose = value;
		this.languageChoose = null;
		this.skillChoose = null;
		this.getQuestionListWithFilter();
	}

	handleChooseSkill(value: any) {
		this.skillChoose = value;
		this.getQuestionListWithFilter();
	}

	handleChooseLanguage(value: any) {
		this.languageChoose = value;
		this.getQuestionListWithFilter();
	}

	getQuestionListWithFilter() {
		const params: any = {
			categoryName: this.valueChoose,
			skillId: this.skillChoose?.skillId,
			skillName: this.skillChoose?.skillName,
			languageId: this.languageChoose?.languageId,
			languageName: this.languageChoose?.languageName,
			softskill: this.valueChoose === 'Soft Skills',
		};

		// this.questionService.getQuestionListWithFilter(params).subscribe(
		// 	(data) => {
		// 		this.rows = data;
		// 	},
		// 	(error) => {
		// 		console.error('Error fetching filtered questions:', error);
		// 	}
		// );
	}

	handleAddModalOpen() {
		// const dialogRef = this.dialog.open(QuestionFormModalComponent, {
		// 	width: '500px',
		// 	data: { skills: this.skills, languages: this.languages }
		// });
		// dialogRef.afterClosed().subscribe(result => {
		// 	if (result) {
		// 		this.questionService.postQuestion(result).subscribe(
		// 			() => {
		// 				this.getQuestionListWithFilter();
		// 				// Show success message
		// 			},
		// 			error => {
		// 				console.error('Error adding question:', error);
		// 				// Show error message
		// 			}
		// 		);
		// 	}
		// });
	}

	handleModalOpen(value: any, type: boolean) {
		// const dialogRef = this.dialog.open(QuestionModalComponent, {
		// 	width: '500px',
		// 	data: { question: value, type, skills: this.skills, languages: this.languages }
		// });
		// dialogRef.afterClosed().subscribe(result => {
		// 	if (result) {
		// 		this.questionService.putQuestion(result).subscribe(
		// 			() => {
		// 				this.getQuestionListWithFilter();
		// 				// Show success message
		// 			},
		// 			error => {
		// 				console.error('Error updating question:', error);
		// 				// Show error message
		// 			}
		// 		);
		// 	}
		// });
	}

	handleDeleteModalOpen(value: any) {
		// const dialogRef = this.dialog.open(DeleteAlertModalComponent, {
		// 	width: '400px',
		// 	data: { question: value }
		// });
		// dialogRef.afterClosed().subscribe(result => {
		// 	if (result) {
		// 		this.questionService.deleteQuestion(value.QuestionId).subscribe(
		// 			() => {
		// 				this.getQuestionListWithFilter();
		// 				// Show success message
		// 			},
		// 			error => {
		// 				console.error('Error deleting question:', error);
		// 				// Show error message
		// 			}
		// 		);
		// 	}
		// });
	}
}
