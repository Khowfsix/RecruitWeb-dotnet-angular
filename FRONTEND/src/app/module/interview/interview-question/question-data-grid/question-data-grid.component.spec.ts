import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionDataGridComponent } from './question-data-grid.component';

describe('QuestionDataGridComponent', () => {
  let component: QuestionDataGridComponent;
  let fixture: ComponentFixture<QuestionDataGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestionDataGridComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(QuestionDataGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
