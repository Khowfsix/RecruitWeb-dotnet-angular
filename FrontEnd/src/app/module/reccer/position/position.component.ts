import { Component, OnInit } from '@angular/core';
import { PositionService } from '../../../data/position/position.service';
import { Position } from '../../../data/position/position.model';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
	selector: 'app-position',
	standalone: true,
	imports: [CommonModule, MatMenuModule, MatButtonModule],
	templateUrl: './position.component.html',
	styleUrl: './position.component.css',
})
export class PositionComponent implements OnInit {
  public fetchedPositions?: Position[];
  public currentPosition: Position = {};
  public currentIndex = -1;
  public title = '';

  constructor(private positionService: PositionService) { }

  ngOnInit(): void {
    this.fetchedAllPositions();
    this.fetchedAllPositionsByCurrentUser();
  }

  fetchedAllPositionsByCurrentUser(): void {
    this.positionService.getAllPositionsByCurrentUser()
      .subscribe({
        next: (data) => {
          // this.fetchedPositions = data;
          console.log('PositionsByCurrentUser', data);
        },
        error: (e) => console.error(e)
      });
  }

  fetchedAllPositions(): void {
    this.positionService.getAllPositions()
      .subscribe({
        next: (data) => {
          this.fetchedPositions = data;
          console.log('positions', this.fetchedPositions);
        },
        error: (e) => console.error(e)
      });
  }
}
