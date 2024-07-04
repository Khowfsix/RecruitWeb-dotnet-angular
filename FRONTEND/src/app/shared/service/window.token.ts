import { InjectionToken } from '@angular/core';

export const WINDOW = new InjectionToken<Window>('WindowToken', {
	factory: () => {
		if (typeof window !== 'undefined') {
			return window;
		}
		throw new Error('Window is not available');
	}
});
