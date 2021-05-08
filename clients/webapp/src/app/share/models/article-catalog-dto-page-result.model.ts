import { ArticleCatalogDto } from './article-catalog-dto.model';
export interface ArticleCatalogDtoPageResult {
  count: number;
  data?: ArticleCatalogDto[] | null;
  pageIndex: number;

}
