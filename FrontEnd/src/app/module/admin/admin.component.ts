import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterOutlet } from '@angular/router';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';
@Component({
	selector: 'app-admin',
	standalone: true,
	imports: [
		RouterOutlet,
		NgbAccordionModule,
		MatButtonModule,

		CommonModule,
	],
	templateUrl: './admin.component.html',
	styleUrl: './admin.component.css',
})
export class AdminComponent {
	constructor(
		private router: Router,
	) { }

	listConsole = [
		{
			title: 'Dashboard',
			children: [
				'Overview', 'Reports', 'Analytics'
			]
		},
		{
			title: 'Table console',
			children: [
				'Skills',
				'Languages',
				'Categories',
				'Companies'
			]
		}
	];

	handleClickRoute(name: string) {
		this.router.navigate([`admin/${name.toLowerCase()}`]);
	}
}
