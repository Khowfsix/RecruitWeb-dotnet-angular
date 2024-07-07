import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventHasPositionComponent } from './event-has-position.component';

describe('EventHasPositionComponent', () => {
	let component: EventHasPositionComponent;
	let fixture: ComponentFixture<EventHasPositionComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [EventHasPositionComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(EventHasPositionComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
