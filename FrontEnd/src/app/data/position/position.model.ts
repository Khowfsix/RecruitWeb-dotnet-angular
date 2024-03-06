import { CategoryPosition } from '../categoryPosition/category-position.model';
import { Company } from '../company/company.model';
import { Language } from '../language/language.model';
import { Recruiter } from '../recruiter/recruiter.model';
import { Requirements } from '../requirements/requirements.model';

export class Position {
	positionId?: string;
	positionName?: string;
	description?: string;
	imageURL?: string;
	salary?: number;
	maxHiringQty?: number;
	startDate?: Date;
	endDate?: Date;
	company?: Company;
	language?: Language;
	recruiter?: Recruiter;
	categoryPosition?: CategoryPosition;
	isDeleted?: boolean;
	requirements?: Requirements[];
}
