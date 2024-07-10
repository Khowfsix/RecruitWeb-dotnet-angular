export class User {
	id?: string;
	fullName?: string;
	dateOfBirth?: Date;
	address?: string;
	imageUrl?: string;
	userName?: string;
	normalizedUserName?: string;
	email?: string;
	normalizedEmail?: string;
	emailConfirmed?: boolean;
	passwordHash?: string;
	securityStamp?: string;
	phoneNumber?: string;
	phoneNumberConfirmed?: boolean;
	twoFactorEnabled?: boolean;
	lockoutEnd?: Date;
	lockoutEnabled?: boolean;
}
