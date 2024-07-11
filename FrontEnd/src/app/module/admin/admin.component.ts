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
				'Overview',
				'Reports',
				'Analytics',
				'Exports',
			]
		},
		{
			title: 'Table console',
			children: [
				'Applications',
				'Roles',
				'User-Roles',
				'Users',
				'Awards',
				'BlackLists',
				'Candidates',
				'Candidate-Has-Skills',
				'Candidate-Join-Events',
				'Category-Positions',
				'Category-Questions',
				'Certificates',
				'CVs',
				'Companies',
				'Educations',
				'Events',
				'Event-Has-Positions',
				'Interviews',
				'Interviewers',
				'Languages',
				'Levels',
				'Personal-Projects',
				'Positions',
				'Questions',
				'Question-Languages',
				'Question-Skills',
				'Recruiters',
				'Reports',
				'Requirements',
				'Rounds',
				'Security-Answers',
				'Security-Questions',
				'Skills',
				'Successful-Candidates',
				'Work-Experiences',
			]
		}
	];

	handleClickRoute(name: string) {
		this.router.navigate([`admin/${name.toLowerCase()}`]);
	}
}
