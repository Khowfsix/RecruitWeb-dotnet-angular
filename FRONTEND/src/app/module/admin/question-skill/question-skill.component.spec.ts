import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionSkillComponent } from './question-skill.component';

describe('QuestionSkillComponent', () => {
	let component: QuestionSkillComponent;
	let fixture: ComponentFixture<QuestionSkillComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [QuestionSkillComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(QuestionSkillComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
