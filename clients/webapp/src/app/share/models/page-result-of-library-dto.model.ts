/**
 * 带分页的结果
 */
export interface PageResultOfLibraryDto {
  count: number;
  data?: LibraryDto[] | null;
  pageIndex: number;

}
