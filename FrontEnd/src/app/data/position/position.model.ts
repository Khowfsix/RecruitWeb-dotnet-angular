import { Department } from "../department/department.model";
import { Language } from "../language/language.model";
import { Recruiter } from "../recruiter/recruiter.model";
import { Requirements } from "../requirements/requirements.model";

export class Position {
    PositionId?: any;
    PositionName?: string;
    Description?: string;
    ImageURL?: boolean;
    Salary?: boolean;
    MaxHiringQty?: boolean;
    StartDate?: boolean;
    EndDate?: boolean;
    Department?: Department;
    Language?: Language;
    Recruiter?: Recruiter;
    isDeleted?: boolean;
    requirements?: Requirements[];
}
