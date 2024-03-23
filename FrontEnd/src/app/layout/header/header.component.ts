import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { AuthService } from '../../core/services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { LogoutDialogComponent } from '../../module/auth/logout-dialog/logout-dialog.component';

@Component({
	selector: 'app-header',
	standalone: true,
	imports: [MatMenuModule, MatIconModule],
	templateUrl: './header.component.html',
	styleUrl: './header.component.css',
})
export class HeaderComponent {
	_user: string | null = this._cookieService.get('jwt');
	constructor(
		public _authService: AuthService,
		private _router: Router,
		private _cookieService: CookieService,
		public _matdialog: MatDialog) {
		this.subscribeToLoginStatus();
	}


	handleClick_Logout(): void {
		const dialogRef = this._matdialog.open(LogoutDialogComponent);
		dialogRef.afterClosed().subscribe((result) => {
			if (result) {
				console.log('logout');
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

	subscribeToLoginStatus() {
		this._authService.isLoggedIn.subscribe((loggedIn) => {
			if (loggedIn) {
				this.updateHeaderForLoggedInUser();
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
	}
}
