import { TestBed } from '@angular/core/testing';

import { CategoryPositionService } from './category-position.service';

describe('CategoryPositionService', () => {
  let service: CategoryPositionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryPositionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
