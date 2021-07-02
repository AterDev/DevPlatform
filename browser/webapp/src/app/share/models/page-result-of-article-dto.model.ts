import { ArticleDto } from './article-dto.model';
/**
 * 带分页的结果
 */
export interface PageResultOfArticleDto {
  count: number;
  data?: ArticleDto[] | null;
  pageIndex: number;

}
