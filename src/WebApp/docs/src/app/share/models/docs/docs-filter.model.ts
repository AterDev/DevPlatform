import { FilterBase } from '../filter-base.model';
export interface DocsFilter extends FilterBase {
  name?: string | null;
  docsCatalogId?: string | null;

}
