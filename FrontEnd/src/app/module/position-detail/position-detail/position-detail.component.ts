import { Component, OnInit } from '@angular/core';
import { Position } from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';

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
	) { }


	private paramPositionId: string = '';

	public fetchPosition?: Position;


	public callApiGetPositionById() {
		this.positionService.getById(this.paramPositionId ?? '')
			.subscribe((data) => {
				if (data.isDeleted) {
					this.router.navigate(['/home']);
				}
				this.fetchPosition = data;
				// console.log('fetchPosition: ', this.fetchPosition);
			});
	}

	ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? ''
		// console.log('paramPositionId', this.paramPositionId)
		this.callApiGetPositionById();
	}
}
