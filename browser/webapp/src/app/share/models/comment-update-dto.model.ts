import { Status } from './status.model';
export interface CommentUpdateDto {
  /**
   * 评论内容
   */
  content?: string | null;
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;

}
