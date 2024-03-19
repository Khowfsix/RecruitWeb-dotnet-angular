import { Component, OnInit } from '@angular/core';
import { Position } from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { CookieService } from 'ngx-cookie-service';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import { ToastrService } from 'ngx-toastr';
import { SkillService } from '../../../data/skill/skill.service';
import { nameTypeInToken } from '../../../core/constants/token.constants';

@Component({
	selector: 'app-position-detail',
	standalone: true,
	imports: [CommonModule, MatTabsModule],
	templateUrl: './position-detail.component.html',
	styleUrl: './position-detail.component.css'
})
export class PositionDetailComponent implements OnInit {
	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private positionService: PositionService,
		private cookieService: CookieService,
		private toastr: ToastrService,
		private skillService: SkillService,
	) { }

	private paramPositionId: string = '';
	public curentUserRoles: string[] | null = null;
	public fetchPosition?: Position;


	public callApiGetPositionById() {
		this.positionService.getById(this.paramPositionId ?? '')
			.subscribe(
				{
					next: (data) => {
						if (data.isDeleted) {
							if (this.curentUserRoles === null || !this.curentUserRoles.includes("Admin")) {
								// this.toastr.error('Some thing wrong. Redirect to home page', 'Error');
								this.router.navigate(['/home']);
							}
						}

						this.fetchPosition = data;
						// console.log('fetchPosition: ', data);
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
						// this.toastr.error('Some thing wrong. Redirect to home page', 'Error');
						this.router.navigate(['/home']);
					}
				}
			);
	}

	public getCurrentUserRoles(): void {
		const token = this.cookieService.get('jwt');
		if (token !== '') {
			const jsonPayload = JSON.stringify(jwtDecode<JwtPayload>(token));
			this.curentUserRoles = JSON.parse(jsonPayload)[nameTypeInToken.roles];
		}
		else {
			this.curentUserRoles = null
		}
	}

	ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? ''
		// console.log('paramPositionId', this.paramPositionId)
		this.callApiGetPositionById();
	}
}
