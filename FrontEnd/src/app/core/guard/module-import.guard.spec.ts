import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { moduleImportGuard } from './module-import.guard';

describe('moduleImportGuard', () => {
	const executeGuard: CanActivateFn = (...guardParameters) =>
		TestBed.runInInjectionContext(() =>
			moduleImportGuard(...guardParameters),
		);

	beforeEach(() => {
		TestBed.configureTestingModule({});
	});

	it('should be created', () => {
		expect(executeGuard).toBeTruthy();
	});
});
