import { Status } from '../enum/status.model';
export interface UserUpdateDto {
  userName?: string | null;
  avatar?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
