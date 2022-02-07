import { LibraryUpdateDto } from '../library/library-update-dto.model';
export interface BatchUpdateOfLibraryUpdateDto {
  ids: string[];
  /**
   * 模型库
   */
  updateDto?: LibraryUpdateDto | null;

}
