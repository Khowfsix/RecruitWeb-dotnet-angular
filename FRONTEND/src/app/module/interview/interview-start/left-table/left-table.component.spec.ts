import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeftTableComponent } from './left-table.component';

describe('LeftTableComponent', () => {
  let component: LeftTableComponent;
  let fixture: ComponentFixture<LeftTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeftTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LeftTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
