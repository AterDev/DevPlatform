import { Status } from './status.model';
export interface RoleUpdateDto {
  /**
   * 角色名称
   */
  name?: string | null;
  /**
   * 图标
   */
  icon?: string | null;
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;

}
