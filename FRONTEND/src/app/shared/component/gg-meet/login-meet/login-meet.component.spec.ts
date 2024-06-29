import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginMeetComponent } from './login-meet.component';

describe('LoginMeetComponent', () => {
  let component: LoginMeetComponent;
  let fixture: ComponentFixture<LoginMeetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginMeetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoginMeetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
