import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobPreferenceComponent } from './job-preference.component';

describe('JobPreferenceComponent', () => {
  let component: JobPreferenceComponent;
  let fixture: ComponentFixture<JobPreferenceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JobPreferenceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JobPreferenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
