import { Component, Input } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
	selector: 'app-footer',
	standalone: true,
	imports: [
		FlexLayoutModule,
		MatGridListModule,
		MatIconModule,
		MatToolbarModule
	],
	templateUrl: './footer.component.html',
	styleUrl: './footer.component.css',
})
export class FooterComponent {
	@Input() deviceXs: boolean | null = false;
}
