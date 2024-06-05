/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SafeUrl } from '@angular/platform-browser';
import { QRCodeModule } from 'angularx-qrcode';

@Component({
	selector: 'app-qrcode-dialog',
	standalone: true,
	imports: [
		QRCodeModule,
	],
	templateUrl: './qrcode-dialog.component.html',
	styleUrl: './qrcode-dialog.component.css'
})
export class QrcodeDialogComponent implements OnInit {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		public dialogRef: MatDialogRef<QrcodeDialogComponent>,
	) { }

	public qrdata: string = this.data.qrdata ?? undefined;
	public qrCodeDownloadLink: SafeUrl = "";

	onChangeURL(url: SafeUrl) {
		this.qrCodeDownloadLink = url;
	}

	ngOnInit(): void {
		console.log('qrdata', this.qrdata)
	}
}
