import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
	selector: 'app-cate-tab',
	standalone: true,
	imports: [
		MatButtonModule,
		MatIconModule,

		CommonModule,
	],
	templateUrl: './cate-tab.component.html',
})
export class CateTabComponent {
	@Input() currentCateTab: number = 0;
	@Output() setCurrentCateTab = new EventEmitter<number>();
}
