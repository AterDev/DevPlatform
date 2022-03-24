import { DocsCatalogItemDto } from '../docs-catalog/docs-catalog-item-dto.model';
export interface PageResultOfDocsCatalogItemDto {
  count: number;
  data?: DocsCatalogItemDto[] | null;
  pageIndex: number;

}
