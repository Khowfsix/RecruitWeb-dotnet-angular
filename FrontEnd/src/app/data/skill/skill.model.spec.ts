import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkillModel } from './skill.model';

describe('SkillModel', () => {
  let component: SkillModel;
  let fixture: ComponentFixture<SkillModel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SkillModel]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SkillModel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
