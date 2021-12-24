import { BaseDB } from './base-db.model';
import { Account } from './account.model';
export interface Role extends BaseDB {
  /**
   * 角色名称
   */
  name?: string | null;
  /**
   * 图标
   */
  icon?: string | null;
  /**
   * 多对多关联账号
   */
  accounts?: Account[] | null;

}
