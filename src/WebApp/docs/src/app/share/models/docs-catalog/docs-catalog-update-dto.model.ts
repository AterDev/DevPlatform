/**
 * 文档目录
 */
export interface DocsCatalogUpdateDto {
  name?: string | null;
  sort?: number | null;
  parentId?: string | null;
  language: string;

}
