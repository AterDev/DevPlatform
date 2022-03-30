import { NewsTagsUpdateDto } from '../news-tags/news-tags-update-dto.model';
export interface BatchUpdateOfNewsTagsUpdateDto {
  ids: string[];
  /**
   * 新闻标签
   */
  updateDto?: NewsTagsUpdateDto | null;

}
