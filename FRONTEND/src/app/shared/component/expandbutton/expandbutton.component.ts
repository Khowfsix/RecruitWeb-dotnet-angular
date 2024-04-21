import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { ElementRef, Renderer2 } from '@angular/core';
@Component({
	selector: 'app-expandbutton',
	standalone: true,
	imports: [
		MatButton,
		CommonModule,
	],
	templateUrl: './expandbutton.component.html',
	styleUrl: './expandbutton.component.css'
})
export class ExpandbuttonComponent implements OnInit {
	@Input()
	public notExpandLabel?: string;
	@Input({ required: true })
	public expandedLabel?: string;

	@Input({ required: true })
	public notExpandedWidth?: string;
	@Input({ required: true })
	public expandedWidth?: string;

	@Input()
	public icon?: 'add' | 'save' | 'delete' | 'multi-mail' | 'mail';
	@Input()
	public color?: 'primary' | 'accent' | 'warn';

	constructor(private elementRef: ElementRef, private renderer: Renderer2) {
	}

	ngOnInit(): void {
		const element = this.elementRef.nativeElement.querySelector('.expandButton');
		this.renderer.setStyle(element, 'width', this.notExpandedWidth);
	}

	isExpanded: boolean = false;
	expandPanel() {
		this.isExpanded = true
		const element = this.elementRef.nativeElement.querySelector('.expandButton');
		this.renderer.setStyle(element, 'width', this.expandedWidth);
	}

	collapsePanel() {
		this.isExpanded = false
		const element = this.elementRef.nativeElement.querySelector('.expandButton');
		this.renderer.setStyle(element, 'width', this.notExpandedWidth);
	}
}
