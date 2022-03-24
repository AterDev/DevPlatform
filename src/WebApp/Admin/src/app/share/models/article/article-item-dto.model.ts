import { ArticleType } from '../enum/article-type.model';
import { Status } from '../enum/status.model';
/**
 * 文章内容
 */
export interface ArticleItemDto {
  /**
   * 标题
   */
  title: string;
  /**
   * 概要
   */
  summary?: string | null;
  /**
   * 作者名称
   */
  authorName?: string | null;
  /**
   * 标签
   */
  tags?: string | null;
  /**
   * 文章类别
   */
  articleType?: ArticleType;
  /**
   * 仅个人查看
   */
  isPrivate?: boolean | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
