import { Status } from './status.model';
export interface RoleDto {
  /**
   * 角色名称
   */
  name?: string | null;
  /**
   * 图标
   */
  icon?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
