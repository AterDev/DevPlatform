import { Status } from '../enum/status.model';
/**
 * 文章扩展
 */
export interface ArticleExtendUpdateDto {
  articleId?: string | null;
  content?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
