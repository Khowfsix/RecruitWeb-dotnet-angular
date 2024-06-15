import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AnalysisComponent } from './analysis/analysis.component';
import { CategoryComponent } from './category/category.component';
import { CompanyComponent } from './company/company.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LanguageComponent } from './language/language.component';
import { ReportComponent } from './report/report.component';
import { SkillComponent } from './skill/skill.component';
import { UserManageComponent } from './user-manage/user-manage.component';

const routes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [
			//Dashboards
			{
				path: '',
				component: DashboardComponent,
				data: { breadcrumb: 'Overview' }

			},
			{
				path: 'overview',
				component: DashboardComponent,
				data: { breadcrumb: 'Overview' }

			},
			{
				path: 'reports',
				component: ReportComponent,
				data: { breadcrumb: 'Reports' }
			},
			{
				path: 'analytics',
				component: AnalysisComponent,
				data: { breadcrumb: 'Analytics' }
			},
			{
				path: 'user-manage',
				component: UserManageComponent,
				data: { breadcrumb: 'User manage' }
			},

			//Table console
			{
				path: 'skills',
				component: SkillComponent,
				data: { breadcrumb: 'Skills manage' }
			},
			{
				path: 'languages',
				component: LanguageComponent,
				data: { breadcrumb: 'Languages manage' }
			},
			{
				path: 'categories',
				component: CategoryComponent,
				data: { breadcrumb: 'Categories manage' }
			},
			{
				path: 'companies',
				component: CompanyComponent,
				data: { breadcrumb: 'Companies manage' }
			},

			// otherwise
			{ path: '**', redirectTo: '' },
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AdminRoutingModule { }
