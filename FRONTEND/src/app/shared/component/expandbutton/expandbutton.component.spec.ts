import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpandbuttonComponent } from './expandbutton.component';

describe('ExpandbuttonComponent', () => {
  let component: ExpandbuttonComponent;
  let fixture: ComponentFixture<ExpandbuttonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExpandbuttonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExpandbuttonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
