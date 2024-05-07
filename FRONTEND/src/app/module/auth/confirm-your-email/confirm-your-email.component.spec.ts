import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmYourEmailComponent } from './confirm-your-email.component';

describe('ConfirmYourEmailComponent', () => {
  let component: ConfirmYourEmailComponent;
  let fixture: ComponentFixture<ConfirmYourEmailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfirmYourEmailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ConfirmYourEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
