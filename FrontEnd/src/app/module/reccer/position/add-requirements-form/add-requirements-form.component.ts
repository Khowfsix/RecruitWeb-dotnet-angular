import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
// import { Observable } from 'rxjs';
// import { map, startWith } from 'rxjs/operators';
import { AsyncPipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SkillService } from '../../../../data/skill/skill.service';
import { Skill } from '../../../../data/skill/skill.model';
import { AutocompleteComponent } from '../../../../shared/component/inputs/autocomplete/autocomplete.component';
import { combineLatest } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { Requirements } from '../../../../data/requirements/requirements.model';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-add-requirements-form',
	standalone: true,
	imports: [
		FormsModule,
		AutocompleteComponent,
		MatFormFieldModule,
		MatInputModule,
		MatAutocompleteModule,
		ReactiveFormsModule,
		MatButtonModule,
		AsyncPipe,],
	templateUrl: './add-requirements-form.component.html',
	styleUrl: './add-requirements-form.component.css'
})
export class AddRequirementsFormComponent {
	@Input({ required: true })
	public fieldName?: string;
	@Input({ required: true })
	public placeholder?: string;
	@Input({ required: true })
	public label?: string;
	@Input({ required: true })
	public formGroup?: FormGroup;
	@Input({ required: true })
	public isEditForm?: boolean;
	public isDisabled = false;
	public observableSkills = this.skillService.getAllSkills();
	public fetchSkills: Skill[] = [];
	public displayRequirements: any[] = [];
	public isUpdateRequirement: boolean = false;

	constructor(
		private skillService: SkillService,
		private formBuilder: FormBuilder,
		private toastr: ToastrService,
	) { }

	public addForm: FormGroup = this.formBuilder.group({
		skillName: [
			// this.isEditForm ? this.fetchObject.language?.languageName : '',
			'',
			[Validators.required]
		],
		experience: [
			// this.isEditForm ? this.fetchObject.positionName : '',
			'',
			[Validators.required]
		],
		notes: [
			// this.isEditForm ? this.fetchObject.description : '',
			'',
			[Validators.required]
		],

	});

	private setupValidators() {
		this.addForm
			.get('skillName')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchSkills.map((x) => x.skillName),
				),
			]);

		this.addForm.get('skillName')?.updateValueAndValidity();
	}

	private isInAllowedValues(allowedValues: any[]): ValidatorFn {
		return (control: AbstractControl): ValidationErrors | null => {
			// console.log('allowedValues:', allowedValues)
			const value = control.value;

			// console.log('vallue', value)

			if (!value) {
				return null;
			}

			return allowedValues.includes(value)
				? null
				: { invalid: 'invalid value' };
		};
	}

	ngOnInit(): void {
		if (this.isEditForm) {
			this.displayRequirements = this.formGroup?.get(this.fieldName ?? '')?.value;
		}

		this.fetchAllSkill();

		combineLatest([
			this.observableSkills,
		]).subscribe(([skills]) => {
			this.fetchSkills = skills;
			this.setupValidators();
		});
	}

	public fetchedSkills?: Skill[];

	public clearAllRequirements() {
		this.displayRequirements = [];
		this.formGroup?.get(this.fieldName ?? '')?.setValue([]);
		console.log('requirements: this.formGroup?.value', this.formGroup?.value)
	}

	public getRequirement(skillId: string) {
		const foundRequirement = this.displayRequirements.find(x => x.skillId === skillId);
		this.addForm.get('skillName')?.setValue(foundRequirement.skillName);
		this.addForm.get('experience')?.setValue(foundRequirement.experience);
		this.addForm.get('notes')?.setValue(foundRequirement.notes);
		this.isUpdateRequirement = true;
	}

	public removeRequirement(skillId: string) {
		if (this.displayRequirements.map(x => x.skillName).includes(this.addForm.get('skillName')?.value)) {
			this.isUpdateRequirement = false;
		}
		this.displayRequirements = this.displayRequirements.filter(x => x.skillId !== skillId);
		const formatedRequirements = this.displayRequirements.map(x => {
			return {
				skillId: x.skillId,
				positionId: '',
				experience: x.experience,
				notes: x.notes,
			}
		})
		this.formGroup?.get(this.fieldName ?? '')?.setValue(formatedRequirements);
		console.log('requirements: this.formGroup?.value', this.formGroup?.value)
		// // console.log('this.requirements', this.displayRequirements)
	}

	public addRequirementToList(): void {
		const currentRequirements: Requirements[] | null = this.formGroup?.get(this.fieldName ?? '')?.value;
		const skillId = this.fetchSkills.find((x) => x.skillName === this.addForm.get('skillName')?.value)?.skillId;
		if (currentRequirements?.map(x => x.skillId).includes(skillId)) {
			this.toastr.error('Skill conflict !!!!');
			return;
		}
		let requirement: any = {
			positionId: '',
			skillId: this.fetchSkills.find((x) => x.skillName === this.addForm.get('skillName')?.value)?.skillId,
			experience: this.addForm.get('experience')?.value,
			notes: this.addForm.get('notes')?.value,
		}
		currentRequirements?.push(requirement)
		requirement = {
			...requirement,
			skillName: this.addForm.get('skillName')?.value,
		}
		this.formGroup?.get(this.fieldName ?? '')?.setValue(currentRequirements);

		this.displayRequirements.push(requirement);

		console.log('requirements: this.formGroup?.value', this.formGroup?.value)
		// // console.log('this.requirements', this.displayRequirements)
	}

	public updateRequirement(): void {
		const skillName = this.addForm.get('skillName')?.value;

		if (!this.displayRequirements.map(x => x.skillName).includes(skillName)) {
			this.toastr.error('Requirement not found!!!')
			return;
		}

		this.displayRequirements = this.displayRequirements.filter(x => x.skillName !== skillName);
		const requirement: any = {
			positionId: '',
			skillName: skillName,
			skillId: this.fetchSkills.find((x) => x.skillName === skillName)?.skillId,
			experience: this.addForm.get('experience')?.value,
			notes: this.addForm.get('notes')?.value,
		}
		this.displayRequirements.push(requirement);

		const formatedRequirements = this.displayRequirements.map(x => {
			return {
				skillId: x.skillId,
				positionId: '',
				experience: x.experience,
				notes: x.notes,
			}
		})
		this.formGroup?.get(this.fieldName ?? '')?.setValue(formatedRequirements);

		this.isUpdateRequirement = false;
		console.log('requirements: this.formGroup?.value', this.formGroup?.value)
		// console.log('this.requirements', this.displayRequirements)
	}

	private fetchAllSkill() {
		this.skillService.getAllSkills().subscribe({
			next: (data: any) => {
				this.fetchedSkills = data;
				console.log("fetchedSkills: ", data);
				if (this.isEditForm)
					if (this.displayRequirements) {
						this.displayRequirements = this.displayRequirements.map(x => {
							x.skillName = this.fetchedSkills?.find(y => y.skillId === x.skillId)?.skillName;
							return x;
						})

						console.log('this.displayRequirements', this.displayRequirements);
					}
			},
			error: (err: any) => {
				console.log('fetchedSkills ERROR:', err);
			}
		}
		);
	}
}
