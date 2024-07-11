/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { ExportService } from '../../../data/export/export.service';
import { Observable } from 'rxjs';

@Component({
	selector: 'app-export',
	standalone: true,
	imports: [
		MatButtonModule,
	],
	templateUrl: './export.component.html',
	styleUrl: './export.component.css'
})
export class ExportComponent {
	constructor(
		public _exportService: ExportService,
	) { }

	public export(api: Observable<any>) {
		api.subscribe((response: any) => {
			const url = window.URL.createObjectURL(response.body);

			const contentDisposition = response.headers.get('Content-Disposition');
			let fileName = 'exported-file.xlsx';
			if (contentDisposition) {
				const matches = /filename="([^"]*)"/.exec(contentDisposition);
				if (matches != null && matches[1]) {
					fileName = matches[1];
				}
			}

			const a = document.createElement('a');
			a.href = url;
			a.download = fileName;

			document.body.appendChild(a);
			a.click();

			document.body.removeChild(a);

			window.URL.revokeObjectURL(url);
		});
	}
}
