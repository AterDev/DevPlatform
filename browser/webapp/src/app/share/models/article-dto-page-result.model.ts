import { ArticleDto } from './article-dto.model';
export interface ArticleDtoPageResult {
  count: number;
  data?: ArticleDto[] | null;
  pageIndex: number;

}
