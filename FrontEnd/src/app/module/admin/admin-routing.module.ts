import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { SkillComponent } from './skill/skill.component';
import { LanguageComponent } from './language/language.component';

const routes: Routes = [
	{
		path: '',
		component: AdminComponent,
	},
	{
		path: 'skill',
		component: SkillComponent,
	},
	{
		path: 'language',
		component: LanguageComponent,
	},
];

@NgModule({
	providers: [],
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AdminRoutingModule { }
