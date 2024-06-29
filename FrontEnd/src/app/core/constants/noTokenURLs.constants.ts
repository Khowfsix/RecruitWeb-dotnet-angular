// import { userId } from "../../shared/service/ggmeet.service";

export const noTokenURLs = [
	'/Authentication/Login',
	'/Authentication/Register',
	'https://accounts.google.com/.well-known/openid-configuration',
	'https://www.googleapis.com/oauth2/v3/certs',
	// Delete when deploy
	// `/zoom-proxy-server/users/${userId}/meetings`,
	// `/refreshtoken-zoom-proxy-server`,
	// Delete when deploy

	// '/Authentication/RefreshToken',
	// add more
];
