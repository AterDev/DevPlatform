import { FilterBase } from './filter-base.model';
export interface ArticleFilter extends FilterBase {
  accountId?: string | null;
  catalogId?: string | null;

}
