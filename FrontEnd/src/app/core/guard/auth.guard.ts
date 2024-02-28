import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, _state) => {
	return true;
};
