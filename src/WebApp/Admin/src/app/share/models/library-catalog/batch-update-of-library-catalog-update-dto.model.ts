import { LibraryCatalogUpdateDto } from '../library-catalog/library-catalog-update-dto.model';
export interface BatchUpdateOfLibraryCatalogUpdateDto {
  ids: string[];
  /**
   * 目录/文件目录 / 自引用
   */
  updateDto?: string | null;

}
