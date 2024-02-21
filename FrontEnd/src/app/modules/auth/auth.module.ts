import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
	declarations: [
		// Khai báo các component của authModule ở đây
	],
	imports: [CommonModule, AuthRoutingModule],
})
export class AuthModule {}
