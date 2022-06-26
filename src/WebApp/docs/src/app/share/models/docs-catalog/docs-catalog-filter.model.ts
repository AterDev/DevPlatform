import { FilterBase } from '../filter-base.model';
export interface DocsCatalogFilter extends FilterBase {
  name?: string | null;
  sort?: number | null;
  parentId?: string | null;
  language?: string | null;

}
