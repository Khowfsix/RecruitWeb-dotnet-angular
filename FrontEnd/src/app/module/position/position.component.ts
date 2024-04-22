/* eslint-disable prefer-const */
/* eslint-disable no-prototype-builtins */
/* eslint-disable @typescript-eslint/no-explicit-any */
import {
	Component,
	OnInit,
	ViewContainerRef,
	Inject,
} from '@angular/core';
import { PositionService } from '../../data/position/position.service';
import { Position } from '../../data/position/position.model';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../data/authentication/authentication.service';
import { WebUser } from '../../data/authentication/web-user.model';
import {
	MAT_DIALOG_DATA,
	MatDialog,
	MatDialogActions,
	MatDialogClose,
	MatDialogContent,
	MatDialogRef,
	MatDialogTitle,
} from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';
import { ToastrService } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import { nameTypeInToken } from '../../core/constants/token.constants';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { FilterComponent } from './filter/filter.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, startWith } from 'rxjs/operators';
import { CustomDateTimeService } from '../../shared/utils/custom-datetime.service';
import { MatSlideToggleChange, MatSlideToggleModule } from '@angular/material/slide-toggle';


@Component({
	selector: 'app-position',
	standalone: true,
	imports: [
		MatSlideToggleModule,
		CommonModule,
		MatMenuModule,
		MatButtonModule,
		RouterModule,
		MatPaginatorModule,
		MatSelectModule,
		FilterComponent
	],
	templateUrl: './position.component.html',
	styleUrl: './position.component.css',
})
export class PositionComponent implements OnInit {
	constructor(
		private dialog: MatDialog,
		private viewContainerRef: ViewContainerRef,
		private formBuilder: FormBuilder,
		private cookieService: CookieService,
		private positionService: PositionService,
		private authenticationService: AuthenticationService,
		private customDateTimeService: CustomDateTimeService,
	) { }
	public fetchedPositions?: Position[];
	public currentUser: WebUser = {};
	public curentUserRoles: string[] | null = null;

	public sortString?: string = 'PositionName_ASC';
	public pageIndex?: number;
	public totalPages?: number;
	public pageSize?: number;
	public totalMatchedInDb?: number;

	private filterSubject = new Subject<any>();

	public handleOnlyMine(event: MatSlideToggleChange) {
		if (event.checked) {
			this.filterForm.get('userId')?.setValue(this.currentUser.id);
		}
		else {

			this.filterForm.get('userId')?.setValue('');
		}
	}

	public filterForm: FormGroup = this.formBuilder.group({
		search: [
			'',
			[]
		],
		userId: ['', []],
		fromSalary: [
			null,
			[Validators.pattern('^[0-9]*$')]
		],
		toSalary: [
			null,
			[Validators.pattern('^[0-9]*$'),]
		],
		fromMaxHiringQty: [
			null,
			[Validators.pattern('^[0-9]*$'),]
		],
		toMaxHiringQty: [
			null,
			[Validators.pattern('^[0-9]*$'),]
		],
		fromDate: [
			null,
			[]
		],
		toDate: [
			null,
			[]
		],
		stringOfCategoryPositionIds: [
			'',
			[Validators.min(1),],
		],
		stringOfCompanyIds: [
			'',
			[Validators.min(1),],
		],
		stringOfLanguageIds: [
			'',
			[Validators.min(1),],
		],
	});

	ngOnDestroy() {
		this.filterSubject.complete();
	}

	ngOnInit(): void {
		const token = this.cookieService.get('jwt');

		if (token !== '') {
			const authenPayload = JSON.parse(JSON.stringify(jwtDecode<JwtPayload>(token)));
			this.curentUserRoles = authenPayload[nameTypeInToken.roles]
		}
		else {
			this.curentUserRoles = null
		}
		this.fetchUserLoginInfo();
		this.fetchedAllPositions();

		this.initFilterValuesChange();
	}

	private initFilterValuesChange() {
		this.filterForm.valueChanges
			.pipe(startWith(null))
			.subscribe(() => {
				const formValue = this.filterForm.value;
				formValue.fromDate = this.customDateTimeService.sameValueToUTC(formValue.fromDate, true);
				formValue.toDate = this.customDateTimeService.sameValueToUTC(formValue.toDate, true);
				if ((formValue.fromSalary !== null) === (formValue.toSalary !== null)
					&& (formValue.fromMaxHiringQty !== null) === (formValue.toMaxHiringQty !== null)) {
					this.filterSubject.next(formValue);
				}
			})

		this.filterSubject.pipe(debounceTime(300)).subscribe((formValue) => {
			this.fetchedAllPositions(formValue);
		});
	}

	handleSortSelect(event: Event) {
		const selectedOption = event.target as HTMLSelectElement;
		const value = selectedOption.value;

		this.sortString = value;
		let formValue = this.filterForm.value;
		formValue.fromDate = this.customDateTimeService.sameValueToUTC(formValue.fromDate, true);
		formValue.toDate = this.customDateTimeService.sameValueToUTC(formValue.toDate, true);
		this.fetchedAllPositions(formValue);
	}

	handlePageEvent(e: PageEvent) {
		this.totalMatchedInDb = e.length;
		this.pageSize = e.pageSize;
		this.pageIndex = e.pageIndex + 1;
		let formValue = this.filterForm.value;
		formValue.fromDate = this.customDateTimeService.sameValueToUTC(formValue.fromDate, true);
		formValue.toDate = this.customDateTimeService.sameValueToUTC(formValue.toDate, true);
		this.fetchedAllPositions(formValue);
	}

	public openDeleteDialog(
		positionId: string,
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		if (positionId !== '') {
			const dialogRef = this.dialog.open(DeleteDialog, {
				viewContainerRef: this.viewContainerRef,
				data: {
					positionId: positionId,
				},
				width: '350px',
				enterAnimationDuration,
				exitAnimationDuration,
			});

			dialogRef.afterClosed().subscribe(() => {
				this.fetchedAllPositions();
			});
		}
	}

	public openEditFormDialog(
		fetchObject: Position,
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		const dialogRef = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				currentUserId: this.currentUser.id,
				isEditForm: true,
				fetchObject: fetchObject,
			},
			width: '600px',
			height: '600px',
			enterAnimationDuration,
			exitAnimationDuration,
		});

		dialogRef.afterClosed().subscribe(() => {
			this.fetchedAllPositions();
		});
	}

	public openAddFormDialog(
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		const dialogRef = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				currentUserId: this.currentUser.id,
			},
			width: '600px',
			height: '600px',
			enterAnimationDuration,
			exitAnimationDuration,
		});

		dialogRef.afterClosed().subscribe(() => {
			this.fetchedAllPositions();
		});
	}

	private fetchUserLoginInfo(): void {
		this.authenticationService.userLogin().subscribe({
			next: (data) => {
				this.currentUser = data;
			},
		});
	}

	public fetchedAllPositions(positionFilterModel?: any): void {
		this.positionService.getAllPositions(
			positionFilterModel,
			this.sortString,
			this.pageIndex,
			this.pageSize,
		).subscribe({
			next: (data) => {
				this.fetchedPositions = data.items;
				this.pageIndex = data.pageIndex;
				this.pageSize = data.pageSize;
				this.totalMatchedInDb = data.totalMatchedInDb;
				this.totalPages = data.totalPages;
			},
		});
	}
}

@Component({
	selector: 'delete-dialog',
	template: `
		<div class="p-2">
			<h2 mat-dialog-title>Delete</h2>
			<mat-dialog-content style="font-weight: 600;">
				Would you like to delete this position?
			</mat-dialog-content>
			<mat-dialog-actions class="justify-content-center">
				<button
					mat-button
					mat-dialog-close
					class="mx-4"
					style="background-color: red; color: white; width: 25%; font-size: 16px;">
					Cancel
				</button>
				<button
					class="mx-4"
					(click)="deleteSubmit()"
					mat-button
					cdkFocusInitial
					style="background-color: green; color: white; width: 25%; font-size: 16px;">
					Ok
				</button>
			</mat-dialog-actions>
		</div>
	`,
	standalone: true,
	imports: [
		MatButtonModule,
		MatDialogActions,
		MatDialogClose,
		MatDialogTitle,
		MatDialogContent,
	],
})
export class DeleteDialog {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		public dialogRef: MatDialogRef<DeleteDialog>,
		private positionService: PositionService,
		private toastr: ToastrService,
	) { }

	public deleteSubmit() {
		this.positionService.delete(this.data.positionId).subscribe({
			next: () => { },
			error: () => {
				this.toastr.error('Something wrong...', 'Error!!!');
			},
			complete: () => {
				this.dialogRef.close();
				this.toastr.success('Position Deleted...', 'Successfully!', {
					timeOut: 2000,
				});
			},
		});
	}
}
