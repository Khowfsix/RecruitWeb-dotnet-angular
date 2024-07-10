import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonTransferComponent } from './button-transfer.component';

describe('ButtonTransferComponent', () => {
  let component: ButtonTransferComponent;
  let fixture: ComponentFixture<ButtonTransferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ButtonTransferComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ButtonTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
