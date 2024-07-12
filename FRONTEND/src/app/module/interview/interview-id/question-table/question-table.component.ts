import { NgSwitch, NgSwitchCase } from '@angular/common';
import { Component, Input } from '@angular/core';
import { CateTabComponent } from './cate-tab/cate-tab.component';
import { RightTableComponent } from './right-table/right-table.component';
import { Round } from '../../../../data/round/round.module';

@Component({
	selector: 'app-question-table',
	templateUrl: './question-table.component.html',
	standalone: true,
	imports: [CateTabComponent, RightTableComponent, NgSwitch, NgSwitchCase],
})
export class QuestionTableComponent {
	@Input() round?: Round[];

	currentCateTab = 0;
	currentSubTab = 0;

	get rightSoft() {
		return this.round![0];
	}
	get rightLang() {
		return this.round![1];
	}
	get rightTech() {
		return this.round![2];
	}

	setCurrentSubTab(value: number) {
		this.currentSubTab = value;
	}
}
