import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateCertificateComponent } from './candidate-certificate.component';

describe('CandidateCertificateComponent', () => {
  let component: CandidateCertificateComponent;
  let fixture: ComponentFixture<CandidateCertificateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CandidateCertificateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CandidateCertificateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
