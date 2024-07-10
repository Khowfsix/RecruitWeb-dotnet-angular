export class Language {
	languageId?: string;
	languageName?: string;
	isDeleted?: boolean;
}

export class LanguageAddModel {
	languageName?: string;
}

export class LanguageUpdateModel {
	languageName?: string;
	isDeleted?: boolean;
}
