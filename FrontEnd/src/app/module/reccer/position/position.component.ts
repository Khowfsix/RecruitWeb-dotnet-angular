import {
	Component,
	OnInit,
	ViewContainerRef,
	Inject,
} from '@angular/core';
import { PositionService } from '../../../data/position/position.service';
import { Position } from '../../../data/position/position.model';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../../data/authentication/authentication.service';
import { WebUser } from '../../../data/authentication/web-user.model';
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
import { nameTypeInToken } from '../../../core/constants/token.constants';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';

@Component({
	selector: 'app-position',
	standalone: true,
	imports: [
		CommonModule,
		MatMenuModule,
		MatButtonModule,
		RouterModule,
		MatPaginatorModule,
		MatSelectModule
	],
	templateUrl: './position.component.html',
	styleUrl: './position.component.css',
})
export class PositionComponent implements OnInit {
	constructor(
		private positionService: PositionService,
		private authenticationService: AuthenticationService,
		private dialog: MatDialog,
		private viewContainerRef: ViewContainerRef,
		private cookieService: CookieService,
	) { }
	public fetchedPositions?: Position[];
	public currentUser: WebUser = {};
	// public title = '';
	public curentUserRoles: string[] | null = null;

	public sortString?: string = 'PositionName_ASC';
	public pageIndex?: number;
	public totalPages?: number;
	public pageSize?: number;
	public totalMatchedInDb?: number;

	ngOnInit(): void {
		const token = this.cookieService.get('jwt');

		// console.log('token is: ', token);
		if (token !== '') {
			// const jsonPayload = JSON.stringify(jwtDecode<JwtPayload>(token));
			// this.curentUserRoles = JSON.parse(jsonPayload)[nameTypeInToken.roles];
			const authenPayload = JSON.parse(JSON.stringify(jwtDecode<JwtPayload>(token)));
			this.curentUserRoles = authenPayload[nameTypeInToken.roles]
			// console.log(this.curentUserRoles);
		}
		else {
			this.curentUserRoles = null
		}
		this.fetchUserLoginInfo();
		this.fetchedAllPositions();
		// this.fetchedAllPositionsByCurrentUser();
	}

	handleSortSelect(value: string) {
		this.sortString = value;
		this.fetchedAllPositions();
	}

	handlePageEvent(e: PageEvent) {
		// this.pageEvent = e;
		this.totalMatchedInDb = e.length;
		this.pageSize = e.pageSize;
		this.pageIndex = e.pageIndex + 1;
		console.log('e.pageIndex', e.pageIndex)
		this.fetchedAllPositions();
	}

	public openDeleteDialog(
		positionId: string,
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		if (positionId !== '') {
			// console.log('before positionId:', positionId);
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
		// console.log('value:', this.currentUser.id)
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
		// console.log('value:', this.currentUser.id)
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
				// console.log('currentUser', data);
			},
			error: (e) => console.error(e),
		});
	}

	private fetchedAllPositionsByCurrentUser(): void {
		this.positionService.getAllPositionsByCurrentUser().subscribe({
			next: () => {
				// this.fetchedPositions = data;
				// console.log('PositionsByCurrentUser', data);
			},
			error: (e) => console.error(e),
		});
	}

	private fetchedAllPositions(): void {
		this.positionService.getAllPositions(
			undefined,
			this.sortString,
			this.pageIndex,
			this.pageSize,
		).subscribe({
			next: (data) => {
				// console.log('data', data)
				this.fetchedPositions = data.items;
				this.pageIndex = data.pageIndex;
				this.pageSize = data.pageSize;
				this.totalMatchedInDb = data.totalMatchedInDb;
				this.totalPages = data.totalPages;
				// console.log('positions', this.fetchedPositions);
				// console.log('pageIndex', this.pageIndex);
				// console.log('pageSize', this.pageSize);
				// console.log('totalMatchedInDb', this.totalMatchedInDb);
				// console.log('totalPages', this.totalPages);
			},
			error: (e) => console.error(e),
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
		// console.log('positionId', this.data.positionId);
		this.positionService.delete(this.data.positionId).subscribe({
			next: () => { },
			error: () => {
				// console.log(err);
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
