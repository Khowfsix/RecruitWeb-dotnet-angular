import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEventHasPositionsComponent } from './add-event-has-positions.component';

describe('AddPositionsComponent', () => {
	let component: AddEventHasPositionsComponent;
	let fixture: ComponentFixture<AddEventHasPositionsComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [AddEventHasPositionsComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(AddEventHasPositionsComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
