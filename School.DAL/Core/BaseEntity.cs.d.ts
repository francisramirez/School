declare module server {
	interface baseEntity {
		creationUser: number;
		creationDate: Date;
		userMod?: number;
		modifyDate?: Date;
		userDeleted?: number;
		deletedDate?: Date;
		deleted: boolean;
	}
}
