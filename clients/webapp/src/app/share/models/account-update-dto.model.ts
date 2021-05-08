import { Status } from './status.model';
export interface AccountUpdateDto {
  /**
   * 邮箱
   */
  email?: string | null;
  /**
   * 密码
            
   */
  password?: string | null;
  /**
   * 用户名
   */
  username?: string | null;
  /**
   * 密码加盐
   */
  hashSalt?: string | null;
  /**
   * 软删除
   */
  isDeleted: boolean;
  /**
   * 密码重试次数
   */
  retryCount: number;
  phone?: string | null;
  phoneConfirm: boolean;
  emailConfirm: boolean;
  /**
   * 头像url
   */
  avatar?: string | null;
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;

}
