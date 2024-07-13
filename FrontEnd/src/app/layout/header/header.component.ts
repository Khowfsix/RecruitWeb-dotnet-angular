import { Component, Input, ViewChild } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule, MatMenuTrigger } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../../core/services/auth.service';
import { LogoutDialogComponent } from '../../module/auth/logout-dialog/logout-dialog.component';
// import { jwtDecode, JwtPayload } from 'jwt-decode';
// import { nameTypeInToken } from '../../core/constants/token.constants';
import { PermissionService } from '../../core/services/permission.service';
import { CategoryPosition } from '../../data/categoryPosition/category-position.model';
import { CategoryPositionService } from '../../data/categoryPosition/category-position.service';
import { WebUser } from '../../data/authentication/web-user.model';

@Component({
	selector: 'app-header',
	standalone: true,
	imports: [
		MatMenuModule,
		MatToolbarModule,
		MatButtonModule,
		MatIconModule,
		FlexLayoutModule,
	],
	templateUrl: './header.component.html',
	styleUrl: './header.component.css',
})
export class HeaderComponent {
	_user: string | null = this._cookieService.get('jwt');
	_isAdmin: boolean = false;
	isMenuOpen = false;
	listCategoryJobs: CategoryPosition[] = [];
	user?: WebUser;
	role?: string[];

	@Input() deviceXs: boolean | null = null;
	@ViewChild(MatMenuTrigger) menuTrigger?: MatMenuTrigger;

	constructor(
		public _authService: AuthService,
		private _categoryPositionService: CategoryPositionService,

		private _permService: PermissionService,
		private _router: Router,
		private _cookieService: CookieService,
		public _matdialog: MatDialog,
	) {
		this.subscribeToLoginStatus();
		this._authService.getCurrentUser().subscribe((data) => {
			this.user = data!;
		});
		const roles = this._permService.getRoleOfUser(
			_authService.getAuthenticationToken()!,
		);
		if (typeof roles !== 'string') {
			this.role = roles;
		} else {
			this.role = [roles];
		}

		this._categoryPositionService
			.getAllCategoryPositions()
			.subscribe((data) => {
				this.listCategoryJobs = data;
			});
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
		this._router.navigate(['/company']);
	}

	handleRouteToJobs(option?: string) {
		if (!option) {
			this._router.navigate(['/positions']);
		}
	}

	handleRouteToJobsOfCategory(category: string) {
		this._router.navigate(['/positions'], {
			queryParams: { category: category },
		});
	}

	subscribeToLoginStatus() {
		this._authService.isLoggedIn.subscribe((loggedIn) => {
			if (loggedIn) {
				this.updateHeaderForLoggedInUser();
				if (
					this._permService
						.getRoleOfUser(this._user!)
						.includes('Admin')
				) {
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
		this._router.navigate(['/cv-manage']);
	}

	handleRouteToProfile() {
		this._router.navigate(['/profile']);
	}

	handleRouteToAdminConsole() {
		this._router.navigate(['/admin']);
	}

	openMenu() {
		if (this.menuTrigger) {
			setTimeout(() => {
				this.menuTrigger!.openMenu();
			}, 300);
		}
	}

	closeMenu() {
		if (this.menuTrigger) {
			setTimeout(() => {
				this.menuTrigger!.closeMenu();
			}, 300);
		}
	}

	handleRouteToRecruiterRegisterConsole() {
		this._router.navigate(['/recruiter/register']);
	}

	handleClick_Interview() {
		this._router.navigate(['/interviews']);
	}
	handleClick_Interviewer() {
		this._router.navigate(['/interviewers']);
	}
	handleClick_Events() {
		this._router.navigate(['/events']);
	}
	handleClick_Positions() {
		this._router.navigate(['/positions']);
	}
	handleClick_Interviewer_interview() {
		this._router.navigate(['/list-interviews']);
	}
}
