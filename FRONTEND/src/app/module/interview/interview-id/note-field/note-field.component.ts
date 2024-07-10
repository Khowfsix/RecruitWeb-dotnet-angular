import { Component, Input, AfterViewInit, ElementRef, ViewChild } from '@angular/core';

@Component({
	selector: 'app-note-field',
	template: `
    <div #noteContainer style="overflow-y: auto; max-height: 5000px;"></div>
  `,
	standalone: true
})
export class NoteFieldComponent implements AfterViewInit {
	@Input() note: string = '';
	@ViewChild('noteContainer') noteContainer!: ElementRef;

	ngAfterViewInit() {
		this.updateNoteContent();
	}

	ngOnChanges() {
		if (this.noteContainer) {
			this.updateNoteContent();
		}
	}

	private updateNoteContent() {
		if (this.noteContainer && this.noteContainer.nativeElement) {
			this.noteContainer.nativeElement.innerHTML = this.note;
		}
	}
}
