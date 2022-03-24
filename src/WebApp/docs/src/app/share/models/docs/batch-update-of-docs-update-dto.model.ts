import { DocsUpdateDto } from '../docs/docs-update-dto.model';
export interface BatchUpdateOfDocsUpdateDto {
  ids: string[];
  /**
   * 文档
   */
  updateDto?: DocsUpdateDto | null;

}
