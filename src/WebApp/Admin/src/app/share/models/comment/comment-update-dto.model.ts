import { Status } from '../enum/status.model';
export interface CommentUpdateDto {
  /**
   * 评论内容
   */
  content?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  articleId?: string | null;
  accountId?: string | null;

}
