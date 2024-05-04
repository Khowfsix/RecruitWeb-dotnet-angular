import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendMultiEmailComponent } from './send-multi-email.component';

describe('SendMultiEmailComponent', () => {
  let component: SendMultiEmailComponent;
  let fixture: ComponentFixture<SendMultiEmailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SendMultiEmailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SendMultiEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
