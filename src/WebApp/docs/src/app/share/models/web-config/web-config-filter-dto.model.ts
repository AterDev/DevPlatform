import { FilterBase } from '../filter-base.model';
export interface WebConfigFilterDto extends FilterBase {
  /**
   * 同步的仓库id
   */
  repositoryId?: number | null;

}
