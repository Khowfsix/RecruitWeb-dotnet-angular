/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Application } from '../../../data/application/application.model';
import { ApplicationService } from '../../../data/application/application.service';
import { DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../../data/authentication/authentication.service';
import { CvHasSkillService } from '../../../data/cvHasSkill/cv-has-skill.service';
import { CandidateService } from '../../../data/candidate/candidate.service';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Subject, debounceTime, startWith } from 'rxjs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { BlackListService } from '../../../data/blacklist/blacklist.service';
import { BlackList } from '../../../data/blacklist/blacklist.model';
import { MatIcon } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@Component({
	selector: 'app-application',
	standalone: true,
	imports: [
		MatSlideToggleModule,
		MatTooltipModule,
		MatIcon,
		MatCheckboxModule,
		ReactiveFormsModule,
		MatInput,
		MatSelectModule,
		MatLabel,
		MatFormField,
		DatePipe,
		CommonModule,
	],
	templateUrl: './application.component.html',
	styleUrl: './application.component.css'
})
export class ApplicationComponent implements OnInit {
	constructor(
		private route: ActivatedRoute,
		private applicationService: ApplicationService,
		private authenticationService: AuthenticationService,
		private cvHasSkillService: CvHasSkillService,
		private candidateService: CandidateService,
		private formBuilder: FormBuilder,
		private blackListService: BlackListService,
	) { }

	public paramPositionId!: string;
	public fetchedApplications?: Application[];
	public fetchedBlackLists?: BlackList[];
	public sortString?: string;

	public filterForm: FormGroup = this.formBuilder.group({
		sortString: [
			'DateTime_DESC',
			[]
		],
		search: [
			'',
			[]
		],
		notInBlackList: [
			false,
			[]
		]
	});

	public isInBlackList(candidateId: string | undefined) {
		return this.fetchedBlackLists?.some(x => x.candidateId === candidateId);
	}

	public handleSortSelect(event: Event) {
		const selectedOption = event.target as HTMLSelectElement;
		const value = selectedOption.value;

		this.sortString = value;
		// this.fetchedAllPositions(this.formatFilterModel(this.filterForm.value));
	}

	private getAllBlackList() {
		this.blackListService.getAll().subscribe((data) => {
			this.fetchedBlackLists = data;
		});
	}

	private getAllApplicationsByPositionId(positionId: string, formValue?: any) {
		// console.log('positionId', positionId)
		// console.log('formValue', formValue)
		this.applicationService.getAllByPositionId(positionId, formValue ? formValue.search : '',
			formValue ? formValue.sortString : '', formValue ? formValue.notInBlackList : '').subscribe((data) => {
				this.fetchedApplications = data;
				this.fetchedApplications.forEach(application => {
					if (application.cv?.candidateId)
						this.candidateService.getById(application.cv?.candidateId).subscribe(candidate => {
							if (application.cv) {
								application.cv.candidate = candidate;
							}
						});
					if (application.cv?.cvid)
						this.cvHasSkillService.getAllByCvId(application.cv?.cvid).subscribe(data => {
							if (application.cv) {
								application.cv.cvHasSkills = data;
							}
						})
				});
			});
	}

	private filterSubject = new Subject<any>();

	public ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? '';
		this.getAllApplicationsByPositionId(this.paramPositionId);
		this.getAllBlackList();

		this.filterForm.valueChanges
			.pipe(startWith(null))
			.subscribe(() => {
				const formValue = this.filterForm.value;
				this.filterSubject.next(formValue);
			})

		this.filterSubject.pipe(debounceTime(300)).subscribe((formValue) => {
			this.getAllApplicationsByPositionId(this.paramPositionId, formValue);
		});
	}
}
