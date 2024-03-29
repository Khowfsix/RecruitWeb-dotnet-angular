/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit } from '@angular/core';
import { Position } from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { SkillService } from '../../../data/skill/skill.service';

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
						this.fetchPosition = data;
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

	ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? ''
		this.callApiGetPositionById();
	}
}
