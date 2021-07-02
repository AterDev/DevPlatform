import { BaseDB } from './base-db.model';
import { Account } from './account.model';
export interface LibraryCatalog extends BaseDB {
  name?: string | null;
  type?: string | null;
  sort: number;
  level: number;
  parent?: LibraryCatalog | null;
  parentId?: string | null;
  /**
   * 所属用户
   */
  account?: Account | null;
  accountId: string;
  /**
   * 子目录
   */
  catalogs?: LibraryCatalog[] | null;

}
