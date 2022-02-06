import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface NewsTagsFilter extends FilterBase {
  name?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  thirdNewsId?: string | null;

}
