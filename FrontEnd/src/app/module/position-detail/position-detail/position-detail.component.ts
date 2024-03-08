import { Component, OnInit, inject } from '@angular/core';
import { Position } from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';
import { ActivatedRoute } from '@angular/router';
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
	private route = inject(ActivatedRoute)

	private paramPositionId: string = '';

	private positionService = inject(PositionService);
	public fetchPosition?: Position;

	public callApiGetPositionById() {
		this.positionService.getById(this.paramPositionId ?? '')
			.subscribe((data) => {
				this.fetchPosition = data;
				console.log('fetchPosition: ', this.fetchPosition);
			});
	}

	ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? ''
		console.log('paramPositionId', this.paramPositionId)
		this.callApiGetPositionById();
	}
}
