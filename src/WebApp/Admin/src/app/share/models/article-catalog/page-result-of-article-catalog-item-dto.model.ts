import { ArticleCatalogItemDto } from '../article-catalog/article-catalog-item-dto.model';
export interface PageResultOfArticleCatalogItemDto {
  count: number;
  data?: ArticleCatalogItemDto[] | null;
  pageIndex: number;

}
