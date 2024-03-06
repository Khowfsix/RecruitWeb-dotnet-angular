import { WebUser } from "../authentication/web-user.model";
import { Company } from "../company/company.model";

export class Recruiter {
    recruiterId?: string;
    userId?: string;
    user?: WebUser;
    departmentId?: string;
    companyId?: string;
    company?: Company;
    isDeleted?: boolean;
}
