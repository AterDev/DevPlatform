import { FilterBase } from '../filter-base.model';
import { ArticleType } from '../enum/article-type.model';
import { Status } from '../enum/status.model';
export interface ArticleFilter extends FilterBase {
  /**
   * 标题
   */
  title?: string | null;
  /**
   * 文章类别
   */
  articleType?: ArticleType | null;
  /**
   * 状态
   */
  status?: Status | null;
  accountId?: string | null;
  extendId?: string | null;
  catalogId?: string | null;

}
