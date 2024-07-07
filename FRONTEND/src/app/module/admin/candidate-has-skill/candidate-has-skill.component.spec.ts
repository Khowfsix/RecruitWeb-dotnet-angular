import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateHasSkillComponent } from './candidate-has-skill.component';

describe('CandidateHasSkillComponent', () => {
	let component: CandidateHasSkillComponent;
	let fixture: ComponentFixture<CandidateHasSkillComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [CandidateHasSkillComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(CandidateHasSkillComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
