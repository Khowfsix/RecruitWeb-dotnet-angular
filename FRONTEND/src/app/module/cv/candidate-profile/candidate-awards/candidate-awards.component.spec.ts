import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateAwardsComponent } from './candidate-awards.component';

describe('CandidateAwardsComponent', () => {
  let component: CandidateAwardsComponent;
  let fixture: ComponentFixture<CandidateAwardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CandidateAwardsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CandidateAwardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
