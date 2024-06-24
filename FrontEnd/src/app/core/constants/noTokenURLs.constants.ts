import { userId } from "../../shared/service/zoom.service";

export const noTokenURLs = [
	'/Authentication/Login',
	'/Authentication/Register',
	// Delete when deploy
	`/zoom-proxy-server/users/${userId}/meetings`,
	`/refreshtoken-zoom-proxy-server`,
	// Delete when deploy

	// '/Authentication/RefreshToken',
	// add more
];
