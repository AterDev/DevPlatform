import { ArticleType } from './article-type.model';
import { Status } from './status.model';
export interface ArticleDto {
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
   * 标签
   */
  tags?: string | null;
  /**
   * 文章类别
   */
  articleType?: ArticleType;
  /**
   * 所属目录
   */
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
