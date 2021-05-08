import { BaseDB } from './base-db.model';
import { ArticleType } from './article-type.model';
import { Account } from './account.model';
import { ArticleExtend } from './article-extend.model';
import { ArticleCatalog } from './article-catalog.model';
export interface Article extends BaseDB {
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
  account?: Account | null;
  /**
   * 文章扩展内容
   */
  extend?: ArticleExtend | null;
  /**
   * 所属目录
   */
  catalog?: ArticleCatalog | null;
  /**
   * 评论
   */
  comments?: Comment[] | null;

}
