export interface DocsCatalogTreeItemDto {
  name: string;
  sort: number;
  id: string;
  children?: DocsCatalogTreeItemDto[] | null;
  parentId?: string | null;
  /**
   * 是否为文档节点
   */
  isDoc: boolean;
  language: string;

}
