import { Status } from '../enum/status.model';
/**
 * 账号表
 */
export interface UserUpdateDto {
  userName?: string | null;
  normalizedUserName?: string | null;
  email?: string | null;
  normalizedEmail?: string | null;
  emailConfirmed?: boolean | null;
  /**
   * A random value that must change whenever a users credentials change (password changed, login removed)
   */
  securityStamp?: string | null;
  /**
   * A random value that must change whenever a user is persisted to the store
   */
  concurrencyStamp?: string | null;
  phoneNumber?: string | null;
  phoneNumberConfirmed?: boolean | null;
  twoFactorEnabled?: boolean | null;
  lockoutEnd?: Date | null;
  lockoutEnabled?: boolean | null;
  accessFailedCount?: number | null;
  /**
   * 最后登录时间
   */
  lastLoginTime?: Date | null;
  /**
   * 软删除
   */
  isDeleted?: boolean | null;
  /**
   * 密码重试次数
   */
  retryCount?: number | null;
  status?: Status | null;
  /**
   * 头像url
   */
  avatar?: string | null;

}
