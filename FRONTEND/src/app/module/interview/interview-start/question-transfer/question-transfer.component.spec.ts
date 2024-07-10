import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionTransferComponent } from './question-transfer.component';

describe('QuestionTransferComponent', () => {
  let component: QuestionTransferComponent;
  let fixture: ComponentFixture<QuestionTransferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestionTransferComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(QuestionTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
