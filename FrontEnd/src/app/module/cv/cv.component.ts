import { Component } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';

@Component({
	selector: 'app-cv',
	standalone: true,
	imports: [MatTabsModule],
	templateUrl: './cv.component.html',
	styleUrl: './cv.component.css'
})
export class CvComponent {

}
