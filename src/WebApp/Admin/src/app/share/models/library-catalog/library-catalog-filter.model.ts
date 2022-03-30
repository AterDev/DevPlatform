import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface LibraryCatalogFilter extends FilterBase {
  name?: string | null;
  sort?: number | null;
  level?: number | null;
  accountId?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  parentId?: string | null;

}
