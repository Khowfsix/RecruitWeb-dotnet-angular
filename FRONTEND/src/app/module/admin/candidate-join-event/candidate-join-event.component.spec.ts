import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateJoinEventComponent } from './candidate-join-event.component';

describe('CandidateJoinEventComponent', () => {
	let component: CandidateJoinEventComponent;
	let fixture: ComponentFixture<CandidateJoinEventComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [CandidateJoinEventComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(CandidateJoinEventComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
