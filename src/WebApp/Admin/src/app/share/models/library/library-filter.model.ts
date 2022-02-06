import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface LibraryFilter extends FilterBase {
  /**
   * 库命名空间
   */
  namespace?: string | null;
  /**
   * 是否有效
   */
  isValid?: boolean | null;
  /**
   * 是否公开
   */
  isPublic?: boolean | null;
  /**
   * 状态
   */
  status?: Status | null;
  userId?: string | null;
  catalogId?: string | null;

}
