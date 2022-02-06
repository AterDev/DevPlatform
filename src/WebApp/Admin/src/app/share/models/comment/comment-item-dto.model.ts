import { Status } from '../enum/status.model';
export interface CommentItemDto {
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
