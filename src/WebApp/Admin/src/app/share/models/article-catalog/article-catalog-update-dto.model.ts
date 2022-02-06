import { Status } from '../enum/status.model';
export interface ArticleCatalogUpdateDto {
  name?: string | null;
  type?: string | null;
  sort?: number | null;
  level?: number | null;
  parentId?: string | null;
  accountId?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
