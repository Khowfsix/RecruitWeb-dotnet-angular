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
	_user: string | null;
	constructor(
		private _authService: AuthService,
		private _router: Router,
		private _cookieService: CookieService,
		public _dialog: MatDialog) {
		this._user = this._cookieService.get('jwt');
	}
	handleClick_Logout(): void {
		const dialogRef = this._dialog.open(LogoutDialogComponent, {});
		dialogRef.afterClosed().subscribe((result) => {
			if (result) {
				this._authService.logout();
			}
		});
	}

	handleClick_Login(): void {
		this._router.navigate(['/auth/login/']);
	}

	handleRouteToHomepage() {
		this._router.navigate(['/']);
	}
}
