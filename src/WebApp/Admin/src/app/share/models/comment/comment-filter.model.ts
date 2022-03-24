import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface CommentFilter extends FilterBase {
  /**
   * 状态
   */
  status?: Status | null;
  articleId?: string | null;
  accountId?: string | null;

}
