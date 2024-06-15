// breadcrumb.service.ts
import { Injectable } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { filter } from 'rxjs/operators';

@Injectable({
	providedIn: 'root',
})
export class BreadcrumbService {
	breadcrumbs: Array<{ label: string, url: string }> = [];
	breadcrumbsUpdated: Subject<Array<{ label: string, url: string }>> = new Subject();

	constructor(private router: Router, private activatedRoute: ActivatedRoute) {
		this.router.events.pipe(
			filter(event => event instanceof NavigationEnd)
		).subscribe(() => {
			this.breadcrumbs = this.createBreadcrumbs(this.activatedRoute.root);
		});
	}

	private createBreadcrumbs(route: ActivatedRoute, url: string = '', breadcrumbs: Array<{ label: string, url: string }> = []): Array<{ label: string, url: string }> {
		const children: ActivatedRoute[] = route.children;

		if (children.length === 0) {
			return breadcrumbs;
		}

		for (const child of children) {
			const routeURL: string = child.snapshot.url.map(segment => segment.path).join('/');
			if (routeURL !== '') {
				url += `/${routeURL}`;
			}

			breadcrumbs.push({ label: child.snapshot.data['breadcrumb'], url: url });
			this.breadcrumbsUpdated.next(breadcrumbs);
			return this.createBreadcrumbs(child, url, breadcrumbs);
		}
		return breadcrumbs;
	}

	get getBreadcrumbs(): Array<{ label: string, url: string }> {
		return this.breadcrumbs;
	}
}
