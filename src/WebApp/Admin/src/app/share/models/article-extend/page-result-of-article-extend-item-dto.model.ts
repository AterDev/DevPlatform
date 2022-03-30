import { ArticleExtendItemDto } from '../article-extend/article-extend-item-dto.model';
export interface PageResultOfArticleExtendItemDto {
  count: number;
  data?: ArticleExtendItemDto[] | null;
  pageIndex: number;

}
