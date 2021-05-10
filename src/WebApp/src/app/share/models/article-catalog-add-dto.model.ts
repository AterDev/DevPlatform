export interface ArticleCatalogAddDto {
  /**
   * 父目录
   */
  name?: string | null;
  type?: string | null;
  sort: number;
  /**
   * 可忽略
   */
  level: number;
  parentId?: string | null;
  /**
   * 可忽略
   */
  accountId: string;

}
