import { CategoryPosition } from '../categoryPosition/category-position.model';
import { Company } from '../company/company.model';
import { Language } from '../language/language.model';
import { Level } from '../level/level.model';
import { Recruiter } from '../recruiter/recruiter.model';
import { Requirements } from '../requirements/requirements.model';

export class Position {
	positionId?: string;
	positionName?: string;
	description?: string;
	imageURL?: string;
	minSalary?: number;
	maxSalary?: number;
	maxHiringQty?: number;
	startDate?: Date;
	endDate?: Date;
	company?: Company;
	language?: Language;
	recruiterId?: string;
	recruiter?: Recruiter;
	levelId?: string;
	level?: Level;
	categoryPositionId?: string;
	categoryPosition?: CategoryPosition;
	isDeleted?: boolean;
	requirements?: Requirements[];
}

export class PositionFilterModel {
	search?: string;
	userId?: boolean;
	fromSalary?: number;
	toSalary?: number;
	negotiatedSalary?: boolean;
	fromMaxHiringQty?: number;
	toMaxHiringQty?: number;
	fromDate?: Date;
	toDate?: Date;
	stringOfLevelIds?: string;
	stringOfCategoryPositionIds?: string;
	stringOfCompanyIds?: string;
	stringOfLanguageIds?: string;
}
