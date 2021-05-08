/**
 * 带分页的结果
 */
export interface PageResultOfLibraryCatalogDto {
  count: number;
  data?: LibraryCatalogDto[] | null;
  pageIndex: number;

}
