import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PDEditDialogComponent } from './pd-edit-dialog.component';

describe('PDEditDialogComponent', () => {
  let component: PDEditDialogComponent;
  let fixture: ComponentFixture<PDEditDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PDEditDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PDEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
