export interface JWT {
	readonly accessToken: string;
	readonly refreshToken: string;
	readonly expirationDate: string;
}
