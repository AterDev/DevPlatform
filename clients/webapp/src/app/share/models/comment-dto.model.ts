import { Status } from './status.model';
export interface CommentDto {
  /**
   * 评论内容
   */
  content?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
