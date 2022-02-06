import { ArticleUpdateDto } from '../article/article-update-dto.model';
export interface BatchUpdateOfArticleUpdateDto {
  ids: string[];
  /**
   * 文章内容
   */
  updateDto?: string | null;

}
