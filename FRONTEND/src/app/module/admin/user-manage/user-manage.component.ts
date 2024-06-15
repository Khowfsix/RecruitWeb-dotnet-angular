import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { WebUser } from '../../../data/authentication/web-user.model';
import { AdminService } from '../../../data/admin/admin.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { BehaviorSubject, Subscription } from 'rxjs';

@Component({
	selector: 'app-user-manage',
	standalone: true,
	imports: [
		MatTableModule,
		MatPaginatorModule,
		MatFormFieldModule,
		MatIconModule,
		MatButtonModule
	],
	templateUrl: './user-manage.component.html',
	styleUrl: './user-manage.component.css'
})
export class UserManageComponent {
	displayedColumns: string[] = ['id', 'username', 'email'];
	listProps: string[] = ['id', 'userName', 'email'];

	dataSource = new MatTableDataSource<WebUser>([]);
	private dataInputSubscription: Subscription = new Subscription();

	pageSizeOptions = [5, 10, 25, 100];
	length = 0;
	pageSize = this.pageSizeOptions[0];
	pageIndex = 0;


	@ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(this._intl, this._changeDetectorRef);
	@ViewChild(MatSort) sort: MatSort = new MatSort();

	constructor(
		private _adminService: AdminService,
		public dialog: MatDialog,
		private _intl: MatPaginatorIntl,
		private _changeDetectorRef: ChangeDetectorRef
	) {
		this.fetchUsers();
	}

	users = new BehaviorSubject<WebUser[]>([]);
	fetchUsers() {
		// fetch data
		this.refeshData();
	}

	ngOnInit() {
		// Subscribe to the BehaviorSubject to get the latest data
		this.dataInputSubscription = this.users.subscribe(data => {
			this.dataSource.data = data;
			// Make sure paginator and sorting are applied
			this.dataSource.paginator = this.paginator;
			this.dataSource.sort = this.sort;
		});

		this.displayedColumns = [...this.displayedColumns, 'action'];
	}

	ngOnDestroy() {
		// Unsubscribe to avoid memory leaks
		if (this.dataInputSubscription) {
			this.dataInputSubscription.unsubscribe();
		}
	}

	refeshData() {
		this._adminService.getAllUsers().subscribe(
			(res) => {
				this.users!.next(res);
				this.dataSource.data = res;
				this.length = res.length;
			}
		)
	}

	applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.dataSource.filter = filterValue.trim().toLowerCase();

		if (this.dataSource.paginator) {
			this.dataSource.paginator.firstPage();
		}
	}

	onPageChange(event: PageEvent) {
		this.pageSize = event.pageSize;
		this.pageIndex = event.pageIndex;
	}

	delete(data: WebUser) {
		console.log(data);
	}

	create() {

	}
}
