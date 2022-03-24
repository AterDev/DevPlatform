import { LibraryCatalogItemDto } from '../library-catalog/library-catalog-item-dto.model';
export interface PageResultOfLibraryCatalogItemDto {
  count: number;
  data?: LibraryCatalogItemDto[] | null;
  pageIndex: number;

}
