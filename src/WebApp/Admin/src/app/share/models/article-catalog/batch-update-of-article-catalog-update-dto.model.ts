import { ArticleCatalogUpdateDto } from '../article-catalog/article-catalog-update-dto.model';
export interface BatchUpdateOfArticleCatalogUpdateDto {
  ids: string[];
  updateDto?: string | null;

}
