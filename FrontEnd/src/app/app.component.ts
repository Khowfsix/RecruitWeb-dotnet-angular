import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FlexLayoutModule, MediaChange, MediaObserver } from '@angular/flex-layout';
import { FlexLayoutServerModule } from '@angular/flex-layout/server'
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { LoadingService } from './shared/service/loading.service';
import { BreadcrumbComponent } from './layout/breadcrumb/breadcrumb.component';
// import { StoreModule } from '@ngrx/store';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [
		// router
		RouterOutlet,

		// layout
		FlexLayoutModule,
		FlexLayoutServerModule,
		HeaderComponent,
		FooterComponent,
		BreadcrumbComponent,

		// loader
		MatProgressSpinnerModule,


		CommonModule],
	templateUrl: './app.component.html',
	styleUrl: './app.component.css',
})
export class AppComponent implements OnInit, OnDestroy {
	public title = 'RecruitmentWeb_FE';
	mediaSub: Subscription = null!;
	deviceXs: boolean = null!;

	constructor(public loader: LoadingService, public mediaObserver: MediaObserver) { }

	ngOnInit(): void {
		this.mediaSub = this.mediaObserver.asObservable().subscribe(
			(changes: MediaChange[]) => {
				changes.forEach(change => {
					// console.log(change.mqAlias);
					this.deviceXs = change.mqAlias === 'xs';
					// console.log(this.deviceXs);
				})
			}
		);
	}

	ngOnDestroy(): void {
		this.mediaSub.unsubscribe();
	}

	public isLoading$ = this.loader.loading$;
}
