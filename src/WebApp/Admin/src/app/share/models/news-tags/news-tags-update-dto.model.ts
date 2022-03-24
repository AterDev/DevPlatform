import { Status } from '../enum/status.model';
/**
 * 新闻标签
 */
export interface NewsTagsUpdateDto {
  name?: string | null;
  color?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  thirdNewsId?: string | null;

}
