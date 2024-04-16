import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
	selector: 'app-upload-cv',
	standalone: true,
	imports: [MatFormFieldModule, MatButtonModule],
	templateUrl: './upload-cv.component.html',
	styleUrl: './upload-cv.component.css'
})
export class UploadCvComponent implements OnInit {
	ngOnInit(): void { }

	onFileSelected(event: Event) {
		const input = event.target as HTMLInputElement;
		if (input.files && input.files.length) {
			const file = input.files[0];
			// Handle the file processing here
			console.log(file);
		}
	}

	onDrop(event: DragEvent) {
		event.preventDefault();
		if (event.dataTransfer && event.dataTransfer.files) {
			const file = event.dataTransfer.files[0];
			// Handle the file processing here
			console.log(file);
		}
	}

	onDragOver(event: Event) {
		event.preventDefault();
		event.stopPropagation();
		// You can add some visual feedback for dragging over
	}

	onDragLeave(event: Event) {
		event.preventDefault();
		event.stopPropagation();
		// You can remove the visual feedback
	}
}
