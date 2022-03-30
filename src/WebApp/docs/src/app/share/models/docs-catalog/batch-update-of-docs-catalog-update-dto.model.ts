import { DocsCatalogUpdateDto } from '../docs-catalog/docs-catalog-update-dto.model';
export interface BatchUpdateOfDocsCatalogUpdateDto {
  ids: string[];
  /**
   * 文档目录
   */
  updateDto?: DocsCatalogUpdateDto | null;

}
