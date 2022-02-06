import { Status } from '../enum/status.model';
/**
 * 账号表
 */
export interface UserItemDto {
  id: string;
  userName: string;
  normalizedUserName?: string | null;
  email: string;
  normalizedEmail?: string | null;
  emailConfirmed: boolean;
  /**
   * A random value that must change whenever a users credentials change (password changed, login removed)
   */
  securityStamp?: string | null;
  /**
   * A random value that must change whenever a user is persisted to the store
   */
  concurrencyStamp: string;
  phoneNumber?: string | null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd?: Date | null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  /**
   * 最后登录时间
   */
  lastLoginTime?: Date | null;
  /**
   * 软删除
   */
  isDeleted: boolean;
  /**
   * 密码重试次数
   */
  retryCount: number;
  /**
   * 0 = Default
1 = Deleted
2 = Invalid
3 = Valid
   */
  status?: Status | null;
  createdTime: Date;
  updatedTime: Date;
  /**
   * 头像url
   */
  avatar?: string | null;

}
