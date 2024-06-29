import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateJobAppliedComponent } from './candidate-job-applied.component';

describe('CandidateJobAppliedComponent', () => {
	let component: CandidateJobAppliedComponent;
	let fixture: ComponentFixture<CandidateJobAppliedComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [CandidateJobAppliedComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(CandidateJobAppliedComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
