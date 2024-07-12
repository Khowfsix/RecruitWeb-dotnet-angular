/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { EventService } from '../../data/event/event.service';
import { Event } from '../../data/event/event.model';
import { CommonModule, Location } from '@angular/common';
import { ExpandbuttonComponent } from '../../shared/component/expandbutton/expandbutton.component';
import { MatDialog } from '@angular/material/dialog';
import { QrcodeDialogComponent } from '../../shared/component/dialog/qrcode-dialog/qrcode-dialog.component';
import { baseUrl } from '../../data/api.service';
import { CandidateJoinEventService } from '../../data/candidateJoinEvent/candidate-join-event.service';
import { AuthService } from '../../core/services/auth.service';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import { nameTypeInToken } from '../../core/constants/token.constants';
import { ToastrService } from 'ngx-toastr';
import { CandidateJoinEvent } from '../../data/candidateJoinEvent/candidate-join-event.model';
import { CandidateListDialogComponent } from '../reccer/event/candidate-list-dialog/candidate-list-dialog.component';
import { Router } from '@angular/router';
import { Position } from '../../data/position/position.model';
import { ApplyDialogComponent } from '../position/apply-dialog/apply-dialog.component';
@Component({
	selector: 'app-event-detail',
	standalone: true,
	templateUrl: './event-detail.component.html',
	styleUrl: './event-detail.component.css',
	imports: [RouterModule, CommonModule, ExpandbuttonComponent],
})
export class EventDetailComponent implements OnInit {
	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,
		private candidateJoinEventService: CandidateJoinEventService,
		private authService: AuthService,
		private eventService: EventService,
		private toastr: ToastrService,
		private _location: Location,
	) {}

	public paramEventId: string = '';
	public fetchedEvent?: Event;
	public alreadyJoinedEvent = false;
	public curentUserRoles: string[] | null = null;
	private fetchedCandidateJoinEvents?: CandidateJoinEvent[];

	private callApiGetEventById() {
		this.eventService.getById(this.paramEventId).subscribe((data) => {
			this.fetchedEvent = data;
		});
	}

	ngOnInit(): void {
		const token = this.authService.getAuthenticationToken() ?? '';
		if (token !== '') {
			const authenPayload = JSON.parse(
				JSON.stringify(jwtDecode<JwtPayload>(token)),
			);
			this.curentUserRoles = authenPayload[nameTypeInToken.roles];
		} else {
			this.curentUserRoles = null;
		}

		if (this.curentUserRoles?.includes('Candidate'))
			this.callApiGetAllCandidateJoinEventByCandidateId();

		// console.log('curentUserRoles', this.curentUserRoles)
		this.paramEventId = this.route.snapshot.paramMap.get('eventId') ?? '';
		this.callApiGetEventById();
	}

	private callApiGetAllCandidateJoinEventByCandidateId() {
		this.candidateJoinEventService
			.getAllByCandidateId(this.authService.getCandidateId_OfUser() ?? '')
			.subscribe((resp) => {
				this.fetchedCandidateJoinEvents = resp;
				// console.log('resp.map(e => e.eventId).includes(this.fetchedEvent?.eventId)', resp.map(e => e.eventId).includes(this.fetchedEvent?.eventId ?? ''))
				if (
					resp.map((e) => e.eventId).includes(this.paramEventId ?? '')
				) {
					this.alreadyJoinedEvent = true;
				}
			});
	}

	public callApiDeleteCandidateJoinEvent() {
		const foundCandidateJoinEvent = this.fetchedCandidateJoinEvents?.find(
			(e) => e.eventId === this.paramEventId,
		);
		this.candidateJoinEventService
			.delete(foundCandidateJoinEvent?.candidateJoinEventId ?? '')
			.subscribe({
				next: (response: any) => {
					if (response === true) {
						this.toastr.success('Left this event', 'Success', {
							toastClass: ' my-custom-toast ngx-toastr',
							timeOut: 3000,
						});
						this.alreadyJoinedEvent = false;
						this.callApiGetAllCandidateJoinEventByCandidateId();
						return;
					}
					this.toastr.error(
						'Left failed. Something wrong',
						'Error!',
						{
							toastClass: ' my-custom-toast ngx-toastr',
							timeOut: 3000,
						},
					);
					return;
				},
				error: () => {
					this.toastr.error(
						'Left failed. Something wrong',
						'Error!',
						{
							toastClass: ' my-custom-toast ngx-toastr',
							timeOut: 3000,
						},
					);
					return;
				},
			});
	}

	public openCandidateListDialog(
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	) {
		this.dialog.open(CandidateListDialogComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				eventId: this.paramEventId,
			},
			width: '700px',
			height: '600px',
			enterAnimationDuration,
			exitAnimationDuration,
		});
	}

	public callApiCandidateJoinEvent() {
		if (!this.authService.checkLoginStatus()) {
			this.router.navigate(['/auth/login']);
			return;
		}
		const data = {
			candidateId: this.authService.getCandidateId_OfUser() ?? null,
			eventId: this.fetchedEvent?.eventId,
		};

		this.candidateJoinEventService.save(data).subscribe({
			next: (response: any) => {
				if (response.candidateJoinEventId) {
					this.toastr.success('Joined this event', 'Success', {
						toastClass: ' my-custom-toast ngx-toastr',
						timeOut: 3000,
					});
					this.alreadyJoinedEvent = true;
					this.callApiGetAllCandidateJoinEventByCandidateId();
					return;
				}
				this.toastr.error('Joined failed. Something wrong', 'Error!', {
					toastClass: ' my-custom-toast ngx-toastr',
					timeOut: 3000,
				});
				return;
			},
			error: () => {
				this.toastr.error('Joined failed. Something wrong', 'Error!', {
					toastClass: ' my-custom-toast ngx-toastr',
					timeOut: 3000,
				});
				return;
			},
		});
	}

	public openQRCodeDialog(
		event: Event,
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	) {
		this.dialog.open(QrcodeDialogComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				qrdata: `${baseUrl}/events/detail/${event.eventId}`,
			},
			width: '400px',
			height: '450px',
			enterAnimationDuration,
			exitAnimationDuration,
		});
	}

	openApplyDialog(position: Position) {
		if (this.authService.checkLoginStatus()) {
			const dialogRef = this.dialog.open(ApplyDialogComponent, {
				width: '600px',
				data: {
					position: position,
					candidateId: this.authService.getCandidateId_OfUser(),
					priority: this.fetchedEvent?.applyPriority,
				},
			});

			dialogRef.afterClosed().subscribe((result) => {
				console.log(result);
			});
		} else {
			this.router.navigate(['/auth/login'], {
				queryParams: { returnUrl: this._location.path() },
			});
		}
	}
}
