import { Status } from '../enum/status.model';
export interface UserItemDto {
  userName: string;
  avatar?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
