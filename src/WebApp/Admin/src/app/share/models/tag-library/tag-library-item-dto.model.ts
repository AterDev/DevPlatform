import { Status } from '../enum/status.model';
/**
 * 标签库
 */
export interface TagLibraryItemDto {
  type: string;
  name: string;
  color?: string | null;
  style?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
