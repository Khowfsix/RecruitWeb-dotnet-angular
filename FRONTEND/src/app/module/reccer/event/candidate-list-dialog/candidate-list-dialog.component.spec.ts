import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateListDialogComponent } from './candidate-list-dialog.component';

describe('CandidateListDialogComponent', () => {
  let component: CandidateListDialogComponent;
  let fixture: ComponentFixture<CandidateListDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CandidateListDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CandidateListDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
