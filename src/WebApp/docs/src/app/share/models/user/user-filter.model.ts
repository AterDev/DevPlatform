import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface UserFilter extends FilterBase {
  userName?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
