import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccessfulCandidateComponent } from './successful-candidate.component';

describe('SuccessfulCandidateComponent', () => {
	let component: SuccessfulCandidateComponent;
	let fixture: ComponentFixture<SuccessfulCandidateComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [SuccessfulCandidateComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(SuccessfulCandidateComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
