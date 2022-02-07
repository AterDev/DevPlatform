import { TagLibraryUpdateDto } from '../tag-library/tag-library-update-dto.model';
export interface BatchUpdateOfTagLibraryUpdateDto {
  ids: string[];
  /**
   * 标签库
   */
  updateDto?: TagLibraryUpdateDto | null;

}
