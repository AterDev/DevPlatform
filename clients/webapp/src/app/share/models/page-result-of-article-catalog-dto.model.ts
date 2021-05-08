/**
 * 带分页的结果
 */
export interface PageResultOfArticleCatalogDto {
  count: number;
  data?: ArticleCatalogDto[] | null;
  pageIndex: number;

}
