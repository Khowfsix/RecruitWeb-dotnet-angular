import { Component } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIcon } from '@angular/material/icon';

@Component({
	selector: 'app-footer',
	standalone: true,
	imports: [MatGridListModule, MatIcon],
	templateUrl: './footer.component.html',
	styleUrl: './footer.component.css',
})
export class FooterComponent {

}
