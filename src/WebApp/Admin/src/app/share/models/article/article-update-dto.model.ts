import { ArticleType } from '../enum/article-type.model';
import { Status } from '../enum/status.model';
/**
 * 文章内容
 */
export interface ArticleUpdateDto {
  /**
   * 标题
   */
  title?: string | null;
  /**
   * 概要
   */
  summary?: string | null;
  /**
   * 作者名称
   */
  authorName?: string | null;
  /**
   * 内容
   */
  content?: string | null;
  /**
   * 标签
   */
  tags?: string | null;
  /**
   * 文章类别
   */
  articleType?: ArticleType | null;
  /**
   * 仅个人查看
   */
  isPrivate?: boolean | null;
  /**
   * 状态
   */
  status?: Status | null;
  accountId?: string | null;

}
