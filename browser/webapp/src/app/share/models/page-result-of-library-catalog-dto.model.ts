import { LibraryCatalogDto } from './library-catalog-dto.model';
/**
 * 带分页的结果
 */
export interface PageResultOfLibraryCatalogDto {
  count: number;
  data?: LibraryCatalogDto[] | null;
  pageIndex: number;

}
