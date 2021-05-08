import { FilterBase } from './filter-base.model';
export interface CommentFilter extends FilterBase {
  articleId?: string | null;
  accountId?: string | null;

}
