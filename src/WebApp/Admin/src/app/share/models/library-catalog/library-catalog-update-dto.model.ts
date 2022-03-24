import { Status } from '../enum/status.model';
/**
 * 目录/文件目录 / 自引用
 */
export interface LibraryCatalogUpdateDto {
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
