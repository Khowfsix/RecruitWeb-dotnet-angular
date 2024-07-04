import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WINDOW } from '../../../service/window.token';

@Component({
	selector: 'app-call-back',
	standalone: true,
	imports: [],
	templateUrl: './call-back.component.html',
	styleUrl: './call-back.component.css'
})
export class CallBackComponent implements OnInit {
	constructor(
		private route: ActivatedRoute,
		@Inject(WINDOW) private _window: Window
	) { }

	ngOnInit(): void {

		this.route.fragment.subscribe(fragment => {
			if (fragment) {
				// console.log('call back fragment:', fragment);
				if (this._window.opener) {
					this._window.opener.postMessage(fragment, this._window.origin);
					this._window.close();
				}
			}
		});
	}
}
