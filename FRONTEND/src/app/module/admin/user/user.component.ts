import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { UserService } from '../../../data/user/user.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { User } from '../../../data/user/user.model';

@Component({
	selector: 'app-user',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './user.component.html',
	styleUrl: './user.component.css'
})
export class UserComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"id",
		"fullName",
		"dateOfBirth",
		"address",
		"userName",
		"email",
		"phoneNumber",
	];
	public displayColumn: string[] = [
		"Id",
		"Full Name",
		"Date Of Birth",
		"Address",
		"UserName",
		"Email",
		"Phone Number",
	];
	public detailDisplayedColumns = [
		"Image Url",
		"Normalized UserName",
		"Normalized Email",
		"Email Confirmed",
		"Password Hash",
		"PhoneNumberConfirmed",
		"Security Stamp",
		"Two Factor Enabled",
		"Lockout End",
		"Lockout Enabled",

	]
	public detailListProps = [
		"imageUrl",
		"normalizedUserName",
		"normalizedEmail",
		"emailConfirmed",
		"passwordHash",
		"phoneNumberConfirmed",
		"securityStamp",
		"twoFactorEnabled",
		"lockoutEnd",
		"lockoutEnabled",
	]
	public listUsers = new BehaviorSubject<User[]>([]);

	constructor(
		public _userService: UserService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._userService.getAllUsers().subscribe(
			users => {
				this.listUsers.next(users);
			},
			error => console.error(error)
		);
	}
}
