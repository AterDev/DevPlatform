import { Status } from './status.model';
export interface CommentAddDto {
  /**
   * 评论内容
   */
  content?: string | null;
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;
  articleId?: string | null;
  accountId?: string | null;

}
