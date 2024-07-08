import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewIdComponent } from './interview-id.component';

describe('InterviewIdComponent', () => {
  let component: InterviewIdComponent;
  let fixture: ComponentFixture<InterviewIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InterviewIdComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InterviewIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
