import { ArticleExtendUpdateDto } from '../article-extend/article-extend-update-dto.model';
export interface BatchUpdateOfArticleExtendUpdateDto {
  ids: string[];
  /**
   * 文章扩展
   */
  updateDto?: string | null;

}
