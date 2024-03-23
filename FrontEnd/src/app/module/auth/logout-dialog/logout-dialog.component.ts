import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
	selector: 'app-logout-dialog',
	standalone: true,
	imports: [MatDialogModule, MatButtonModule],
	templateUrl: './logout-dialog.component.html',
})
export class LogoutDialogComponent { }
