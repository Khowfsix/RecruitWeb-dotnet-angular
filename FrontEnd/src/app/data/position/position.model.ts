import { Department } from "../department/department.model";
import { Language } from "../language/language.model";
import { Recruiter } from "../recruiter/recruiter.model";
import { Requirements } from "../requirements/requirements.model";

export class Position {
    positionId?: string;
    positionName?: string;
    description?: string;
    imageURL?: string;
    salary?: number;
    maxHiringQty?: number;
    startDate?: Date;
    endDate?: Date;
    department?: Department;
    language?: Language;
    recruiter?: Recruiter;
    isDeleted?: boolean;
    requirements?: Requirements[];
}
