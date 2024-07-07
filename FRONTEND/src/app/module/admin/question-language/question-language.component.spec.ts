import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionLanguageComponent } from './question-language.component';

describe('QuestionLanguageComponent', () => {
	let component: QuestionLanguageComponent;
	let fixture: ComponentFixture<QuestionLanguageComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [QuestionLanguageComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(QuestionLanguageComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
