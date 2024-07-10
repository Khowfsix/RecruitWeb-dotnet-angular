/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
	selector: 'app-delete-modal',
	standalone: true,
	imports: [
		CommonModule,
		MatButtonModule,
		MatIconModule,
		MatProgressSpinnerModule
	],
	templateUrl: './delete-modal.component.html',
	styleUrl: './delete-modal.component.css'
})
export class DeleteModalComponent {
	@Input() deleteModalStatus: boolean = false;
	@Input() status: { status: string } = { status: '' };
	@Input() value: { QuestionId: string } = { QuestionId: '' };
	@Output() handleDeleteModalClose = new EventEmitter<void>();
	@Output() handleDeleteQuestion = new EventEmitter<any>();

	ngOnChanges(changes: SimpleChanges) {
		if (changes['status'] && this.status.status === 'success') {
			this.handleDeleteModalClose.emit();
		}
	}

	onDeleteClick() {
		this.handleDeleteQuestion.emit(this.value);
	}
}
