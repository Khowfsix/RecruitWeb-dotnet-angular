/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core'
import { FormGroup } from '@angular/forms';
@Injectable({
	providedIn: 'root',
})
export class fileFormatter {
	public generateNewFileName(originalFileName: string): string {
		const randomString = Math.random().toString(36).substring(2, 8);
		return `${originalFileName}_${randomString}`;
	}

	public onFileSelected(data: any, formGroup: FormGroup, fieldFileName: string, fieldFileValue: string) {
		const file = data.target?.files?.[0];
		if (file) {
			const newFileName = this.generateNewFileName(file.name);
			const renamedFile = new File([file], newFileName, { type: file.type });

			formGroup.get(fieldFileName)?.setValue(file.name)
			formGroup.get(fieldFileValue)?.setValue(renamedFile)
		}
	}
}
