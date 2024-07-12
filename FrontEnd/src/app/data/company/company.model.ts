export class Company {
	companyId?: string;
	companyName?: string;
	address?: string;
	email?: string;
	phone?: string;
	website?: string;
	isDeleted?: boolean;
	isActived?: boolean;
	logo?: string;
}

export class CompanyAddModel {
	companyName?: string;
	address?: string;
	email?: string;
	phone?: string;
	website?: string;
	isDeleted?: boolean;
	isActived?: boolean;
	logo?: string;
}


export class CompanyUpdateModel {
	companyName?: string;
	address?: string;
	email?: string;
	phone?: string;
	website?: string;
	isDeleted?: boolean;
	isActived?: boolean;
	logo?: string;
}
