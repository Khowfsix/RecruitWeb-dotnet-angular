import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { PositionService } from '../../../data/position/position.service';
import { Position } from '../../../data/position/position.model';

@Component({
	selector: 'app-position',
	standalone: true,
	imports: [MatTableModule, MatCardModule],
	templateUrl: './position.component.html',
	styleUrl: './position.component.css',
})
export class PositionComponent implements OnInit {
	positions?: Position[];
	currentPosition: Position = {};
	currentIndex = -1;
	title = '';

	constructor(private positionService: PositionService) {}

	ngOnInit(): void {
		// this.retrieveTutorials();
	}

	retrieveTutorials(): void {
		this.positionService.getAll().subscribe({
			next: (data) => {
				this.positions = data;
				console.log(data);
			},
			error: (e) => console.error(e),
		});
	}
}
