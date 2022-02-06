import { Status } from '../enum/status.model';
/**
 * 新闻标签
 */
export interface NewsTagsItemDto {
  name: string;
  color?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
