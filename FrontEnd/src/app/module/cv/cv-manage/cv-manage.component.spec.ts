import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CvManageComponent } from './cv-manage.component';

describe('CvManageComponent', () => {
	let component: CvManageComponent;
	let fixture: ComponentFixture<CvManageComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [CvManageComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(CvManageComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
