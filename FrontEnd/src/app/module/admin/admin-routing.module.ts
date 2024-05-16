import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { SkillComponent } from './skill/skill.component';
import { LanguageComponent } from './language/language.component';
import { CategoryComponent } from './category/category.component';
import { CompanyComponent } from './company/company.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReportComponent } from './report/report.component';
import { AnalysisComponent } from './analysis/analysis.component';

const routes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [
			//Dashboards
			{
				path: '',
				component: DashboardComponent
			},
			{
				path: 'overview',
				component: DashboardComponent
			},
			{
				path: 'reports',
				component: ReportComponent
			},
			{
				path: 'analytics',
				component: AnalysisComponent
			},

			//Table console
			{
				path: 'skills',
				component: SkillComponent
			},
			{
				path: 'languages',
				component: LanguageComponent
			},
			{
				path: 'categories',
				component: CategoryComponent
			},
			{
				path: 'companies',
				component: CompanyComponent
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
