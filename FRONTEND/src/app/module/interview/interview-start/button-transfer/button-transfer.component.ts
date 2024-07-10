/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
	selector: 'app-button-transfer',
	standalone: true,
	imports: [
		CommonModule,
		MatIconModule,
		MatButtonModule
	],
	templateUrl: './button-transfer.component.html',
	styleUrl: './button-transfer.component.css'
})
export class ButtonTransferComponent {
	@Input() currentChosen: any[] = [];
	@Output() transfer = new EventEmitter<void>();

	onTransfer() {
		this.transfer.emit();
	}
}
