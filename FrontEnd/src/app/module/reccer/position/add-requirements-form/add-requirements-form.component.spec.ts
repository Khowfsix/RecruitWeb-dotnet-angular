import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRequirementsFormComponent } from './AddRequirementsFormComponent';

describe('AddRequirementsFormComponent', () => {
  let component: AddRequirementsFormComponent;
  let fixture: ComponentFixture<AddRequirementsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRequirementsFormComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AddRequirementsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
