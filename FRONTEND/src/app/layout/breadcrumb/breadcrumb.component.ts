import { Component, OnInit } from '@angular/core';
import { BreadcrumbService } from './breadcrumb.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
	selector: 'app-breadcrumb',
	standalone: true,
	imports: [
		CommonModule,
		RouterModule
	],
	templateUrl: './breadcrumb.component.html',
	styleUrls: ['./breadcrumb.component.css'],
})
export class BreadcrumbComponent implements OnInit {
	breadcrumbs: Array<{ label: string, url: string }> = [];

	constructor(private breadcrumbService: BreadcrumbService) { }

	ngOnInit(): void {
		this.breadcrumbService.breadcrumbsUpdated.subscribe(
			(data) => {
				this.breadcrumbs = data.filter(breadcrumb => breadcrumb.url !== '');
				this.breadcrumbs = this.breadcrumbs.filter((value, index, self) =>
					index === self.findIndex((t) => (
						t.label === value.label && t.url === value.url
					))
				);
			}
		)
	}
}
