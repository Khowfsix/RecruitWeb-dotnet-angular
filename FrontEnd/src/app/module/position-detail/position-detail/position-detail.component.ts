/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule, Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { Position } from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';
import { SkillService } from '../../../data/skill/skill.service';
import { ApplyDialogComponent } from '../../position/apply-dialog/apply-dialog.component';
import { ApplicationService } from '../../../data/application/application.service';
import { Application } from '../../../data/application/application.model';
import { PermissionService } from '../../../core/services/permission.service';
import { CookieService } from 'ngx-cookie-service';

export type isAvalable = "available" | "full" | "outOfDate" | "reapply";

@Component({
	selector: 'app-position-detail',
	standalone: true,
	imports: [
		CommonModule,
		MatTabsModule,
		MatButtonModule
	],
	templateUrl: './position-detail.component.html',
	styleUrl: './position-detail.component.css'
})
export class PositionDetailComponent implements OnInit {
	constructor(
		private _authService: AuthService,
		private _permissionService: PermissionService,
		private _cookieService: CookieService,

		private router: Router,
		private route: ActivatedRoute,
		private positionService: PositionService,
		private skillService: SkillService,
		private applicationService: ApplicationService,

		public dialog: MatDialog,
		private _location: Location
	) {
		this.curentUserRoles = _permissionService.getRoleOfUser(_cookieService.get("jwt")) as string[];
		console.log(this.curentUserRoles);
	}

	private paramPositionId: string = '';
	public curentUserRoles: string[] | null = null;
	public fetchPosition?: Position;

	isLoggedIn: boolean = false;
	isAvailable: isAvalable = 'available';

	public callApiGetPositionById() {
		this.positionService.getById(this.paramPositionId ?? '')
			.subscribe(
				{
					next: (data) => {
						this.fetchPosition = data;

						const endDate: Date = new Date(this.fetchPosition!.endDate!);
						if (endDate.getTime() < new Date().getTime()) {
							this.isAvailable = "outOfDate";
						}

						this.fetchPosition.requirements?.forEach(x => {
							this.skillService.getSkillById(x.skillId).subscribe({
								next: (response: any) => {
									x.skill = response;
								}
							})
						});

						this.fetchPosition.requirements = this.fetchPosition.requirements?.filter(e => e.isDeleted === false);
					},
					error: () => {
						this.router.navigate(['/home']);
					}
				}
			);
	}

	public handleClickApply() {
		if (this._authService.checkLoginStatus()) {
			this.openDialog();
		}
		else {
			this.router.navigate(['/auth/login'], {
				queryParams: { returnUrl: this._location.path() },
			});
		}
	}

	public openDialog() {
		const dialogRef = this.dialog.open(ApplyDialogComponent, {
			width: '600px',
			data: {
				position: this.fetchPosition,
				candidateId: this._authService.getCandidateId_OfUser()
			}
		});

		dialogRef.afterClosed().subscribe(
			(result) => {
				console.log(result);
			}
		);
	}

	ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? ''
		this.callApiGetPositionById();
		this.isLoggedIn = this._authService.checkLoginStatus();
		if (this.isLoggedIn) {
			this.checkIfCandidateAppliedToThisPosition();
		}
	}


	checkIfCandidateAppliedToThisPosition() {
		const candidateId = this._authService.getCandidateId_OfUser();
		const positionId = this.paramPositionId;

		this.applicationService.getApplicationsOfCandidate(candidateId!)
			.subscribe({
				next: (data: Application[]) => {
					if (data.filter(x => x.position?.positionId === positionId).length > 0) {
						this.isAvailable = "reapply";
					}
					return false;
				},
				error: () => {
					return true;
				}
			});
		return true;
	}
}
