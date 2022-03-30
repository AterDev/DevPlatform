import { Status } from '../enum/status.model';
/**
 * 标签库
 */
export interface TagLibraryUpdateDto {
  type?: string | null;
  name?: string | null;
  color?: string | null;
  style?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
