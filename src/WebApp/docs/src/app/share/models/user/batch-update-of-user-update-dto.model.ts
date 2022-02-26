import { UserUpdateDto } from '../user/user-update-dto.model';
export interface BatchUpdateOfUserUpdateDto {
  ids: string[];
  updateDto?: UserUpdateDto | null;

}
