import { Component } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-position',
  standalone: true,
  imports: [MatTableModule, MatCardModule],
  templateUrl: './position.component.html',
  styleUrl: './position.component.css'
})
export class PositionComponent {
  public dataSource = [1, 2, 3];
  public actions: string[] = ['View & Edit', 'Delete'];
  public columnsToDisplay: string[] = ['No.', 'PositionName', 'Salary', 'MaxHiringQty', 'StartDate', 'EndDate', 'Department', 'Language', 'Recruiter', 'Actions'];
}
