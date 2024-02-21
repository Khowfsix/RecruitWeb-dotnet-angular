import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
	declarations: [
		// các components, directives, và pipes mà module này quản lý
	],
	imports: [
		// các module khác mà module này cần để chạy
		CommonModule,
		AuthRoutingModule,
	],
	exports: [
		// các thành phần mà module này muốn xuất khẩu để module khác có thể sử dụng
	],
})
export class AuthModule {}
