import { Injectable } from "@angular/core";
import { API } from "../api.service";
import { Observable } from "rxjs";
import { WebUser } from "../authentication/web-user.model";

@Injectable({
	providedIn: "root"
})
export class AdminService {
	constructor(
		private _api: API) {
	}

	public getAllUsers(): Observable<WebUser[]> {
		return this._api.GET('/api/Admin/GetAllUsers')
	}
}
