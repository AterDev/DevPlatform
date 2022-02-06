import { ArticleItemDto } from '../article/article-item-dto.model';
export interface PageResultOfArticleItemDto {
  count: number;
  data?: ArticleItemDto[] | null;
  pageIndex: number;

}
