import { Component, OnInit } from '@angular/core';
import { GGMeetService } from '../../../service/ggmeet.service';

@Component({
	selector: 'app-login-meet',
	standalone: true,
	imports: [],
	templateUrl: './login-meet.component.html',
	styleUrl: './login-meet.component.css'
})
export class LoginMeetComponent implements OnInit {
	constructor(
		private ggmeetService: GGMeetService,
	) { }

	ngOnInit(): void {
		this.ggmeetService.login();
	}
}
