import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../../core/services/auth.service';
import { LogoutDialogComponent } from '../../module/auth/logout-dialog/logout-dialog.component';
import { FlexLayoutModule } from '@angular/flex-layout';

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

	@Input() deviceXs: boolean | null = null;

	constructor(
		public _authService: AuthService,
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

	handleRouteToCompanies() {
		this._router.navigate(['/companies']);
	}

	handleRouteToJobs() {
		this._router.navigate(['/positions']);
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

	handleRouteToCVManage() {
		this._router.navigate(['/cv/'])
	}
}
