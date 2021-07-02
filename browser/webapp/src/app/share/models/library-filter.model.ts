import { FilterBase } from './filter-base.model';
export interface LibraryFilter extends FilterBase {
  userId?: string | null;
  catalogId?: string | null;

}
