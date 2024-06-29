import { Component, Input } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../../core/services/auth.service';
import { LogoutDialogComponent } from '../../module/auth/logout-dialog/logout-dialog.component';
// import { jwtDecode, JwtPayload } from 'jwt-decode';
// import { nameTypeInToken } from '../../core/constants/token.constants';
import { PermissionService } from '../../core/services/permission.service';

@Component({
	selector: 'app-header',
	standalone: true,
	imports: [
		MatMenuModule,
		MatToolbarModule,
		MatButtonModule,
		MatIconModule,
		FlexLayoutModule
	],
	templateUrl: './header.component.html',
	styleUrl: './header.component.css',
})
export class HeaderComponent {
	_user: string | null = this._cookieService.get('jwt');
	_isAdmin: boolean = false;

	@Input() deviceXs: boolean | null = null;
	// @ViewChild('jobMenuTrigger') jobMenuTrigger: MatMenuTrigger = new MatMenuTrigger();

	constructor(
		public _authService: AuthService,
		private _permService: PermissionService,

		private _router: Router,
		private _cookieService: CookieService,
		public _matdialog: MatDialog) {
		this.subscribeToLoginStatus();
		// console.log(this.deviceXs);
	}


	handleClick_Logout(): void {
		const dialogRef = this._matdialog.open(LogoutDialogComponent);
		dialogRef.afterClosed().subscribe((result) => {
			if (result) {
				this._authService.logout();
				this._user = null;
			}
		});
	}

	handleClick_Login() {
		this._router.navigate(['/auth/login/']);
	}

	handleRouteToHomepage() {
		this._router.navigate(['/']);
	}

	handleRouteToCompanies() {
		this._router.navigate(['/companies']);
	}

	handleRouteToJobs(option?: string) {
		if (!option) {
			this._router.navigate(['/positions']);
		}
	}

	subscribeToLoginStatus() {
		this._authService.isLoggedIn.subscribe((loggedIn) => {
			if (loggedIn) {
				this.updateHeaderForLoggedInUser();
				if (this._permService.getRoleOfUser(this._user).includes('Admin')) {
					this.updateHeaderForAdmin();
				}
				// this.updateHeaderForAdmin();
			} else {
				this.updateHeaderForLoggedOutUser();
			}
		});
	}



	updateHeaderForLoggedInUser() {
		// logic to update header for logged-in user
		this._user = this._cookieService.get('jwt');
		// ... other updates
	}

	updateHeaderForLoggedOutUser() {
		// logic to update header for logged-out user
		this._user = null;
		// ... other updates
		this._isAdmin = false;
	}

	updateHeaderForAdmin() {
		// logic to update header for admin
		this._isAdmin = true;
		// ... other updates
	}

	handleRouteToCVManage() {
		this._router.navigate(['/cv-manage'])
	}

	handleRouteToProfile() {
		this._router.navigate(['/profile'])
	}

	handleRouteToAdminConsole() {
		this._router.navigate(['/admin'])
	}
}
