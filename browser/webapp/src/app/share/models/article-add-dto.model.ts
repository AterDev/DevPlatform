import { ArticleType } from './article-type.model';
export interface ArticleAddDto {
  /**
   * 标题
   */
  title?: string | null;
  /**
   * 概要
   */
  summary?: string | null;
  /**
   * 标签
   */
  tags?: string | null;
  /**
   * 文章类别
   */
  articleType?: ArticleType;
  /**
   * 文章内容
   */
  content?: string | null;
  accountId: string;
  catalogId: string;

}
