import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';

@Component({
	selector: 'app-title-divider',
	standalone: true,
	imports: [
		CommonModule,
		MatDividerModule,
		MatButtonModule
	],
	templateUrl: './title-divider.component.html',
	styleUrls: ['./title-divider.component.scss']
})
export class TitleDividerComponent {
	@Input() title: string = '';
}
