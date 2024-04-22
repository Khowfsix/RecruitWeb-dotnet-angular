/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { AsyncPipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SkillService } from '../../../data/skill/skill.service';
import { Skill } from '../../../data/skill/skill.model';
import { AutocompleteComponent } from '../../../shared/component/inputs/autocomplete/autocomplete.component';
import { combineLatest } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { Requirements } from '../../../data/requirements/requirements.model';
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
	public fieldName!: string;
	@Input({ required: true })
	public placeholder!: string;
	@Input({ required: true })
	public label!: string;
	@Input({ required: true })
	public formGroup!: FormGroup;
	@Input({ required: true })
	public isEditForm!: boolean;
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
		skillId: [
			'',
			[Validators.required]
		],
		experience: [
			'',
			[Validators.required]
		],
		notes: [
			'',
			[]
		],

	});

	private setupValidators() {
		this.addForm
			.get('skillId')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchSkills.map((x) => x.skillId),
				),
			]);

		this.addForm.get('skillId')?.updateValueAndValidity();
	}

	private isInAllowedValues(allowedValues: any[]): ValidatorFn {
		return (control: AbstractControl): ValidationErrors | null => {
			const value = control.value;

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
			this.displayRequirements = this.formGroup?.get(this.fieldName)?.value;
			console.log(this.displayRequirements)
		}
		this.fetchAllSkill();

		combineLatest([
			this.observableSkills,
		]).subscribe(([skills]) => {
			this.fetchSkills = skills;
			this.setupValidators();
		});
	}

	public clearAllRequirements() {
		this.displayRequirements = [];
		this.formGroup?.get(this.fieldName)?.setValue([]);
		this.isUpdateRequirement = false;
	}

	public getRequirement(skillId: string) {
		const foundRequirement = this.displayRequirements.find(x => x.skillId === skillId);
		this.addForm.get('skillId')?.setValue(foundRequirement.skillId);
		this.addForm.get('experience')?.setValue(foundRequirement.experience);
		this.addForm.get('notes')?.setValue(foundRequirement.notes);
		this.isUpdateRequirement = true;
	}

	public removeRequirement(skillId: string) {
		if (this.displayRequirements.map(x => x.skillId).includes(this.addForm.get('skillId')?.value)) {
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
		this.formGroup?.get(this.fieldName)?.setValue(formatedRequirements);
	}

	public addRequirementToList(): void {
		const currentRequirements: Requirements[] | null = this.formGroup?.get(this.fieldName)?.value;
		const skillId = this.addForm.get('skillId')?.value;
		if (currentRequirements?.map(x => x.skillId).includes(skillId)) {
			this.toastr.error('Skill conflict !!!!');
			return;
		}
		let requirement: any = {
			positionId: '',
			skillId: this.addForm.get('skillId')?.value,
			experience: this.addForm.get('experience')?.value,
			notes: this.addForm.get('notes')?.value,
		}
		currentRequirements?.push(requirement)
		requirement = {
			...requirement,
			skillName: this.fetchSkills?.find(e => e.skillId === this.addForm.get('skillId')?.value)?.skillName,
		}
		this.formGroup?.get(this.fieldName ?? '')?.setValue(currentRequirements);

		this.displayRequirements.push(requirement);
	}

	public updateRequirement(): void {
		const skillId = this.addForm.get('skillId')?.value;

		if (!this.displayRequirements.map(x => x.skillId).includes(skillId)) {
			this.toastr.error('Requirement not found!!!')
			return;
		}

		this.displayRequirements = this.displayRequirements.filter(x => x.skillId !== skillId);
		const requirement: any = {
			positionId: '',
			skillId: skillId,
			skillName: this.fetchSkills.find(e => e.skillId === skillId)?.skillName,
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
	}

	private fetchAllSkill() {
		this.skillService.getAllSkills().subscribe({
			next: (data: any) => {
				this.fetchSkills = data;
				if (this.isEditForm)
					if (this.displayRequirements) {
						this.displayRequirements = this.displayRequirements.map(x => {
							x.skillName = this.fetchSkills?.find(y => y.skillId === x.skillId)?.skillName;
							return x;
						})
					}
			},
		}
		);
	}
}
