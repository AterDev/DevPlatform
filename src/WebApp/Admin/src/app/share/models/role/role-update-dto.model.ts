import { Status } from '../enum/status.model';
/**
 * 角色表
 */
export interface RoleUpdateDto {
  name?: string | null;
  normalizedName?: string | null;
  concurrencyStamp?: string | null;
  /**
   * 图标
   */
  icon?: string | null;
  status?: Status | null;

}
