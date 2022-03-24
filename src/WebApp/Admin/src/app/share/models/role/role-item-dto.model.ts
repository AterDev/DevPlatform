import { Status } from '../enum/status.model';
/**
 * 角色表
 */
export interface RoleItemDto {
  id: string;
  name: string;
  normalizedName?: string | null;
  concurrencyStamp: string;
  /**
   * 图标
   */
  icon?: string | null;
  /**
   * 0 = Default
1 = Deleted
2 = Invalid
3 = Valid
   */
  status?: Status | null;
  createdTime: Date;
  updatedTime: Date;

}
