import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface ArticleExtendFilter extends FilterBase {
  articleId?: string | null;
  content?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
