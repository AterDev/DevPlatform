import { Role } from './role.model';
import { Status } from './status.model';
export interface AccountDto {
  /**
   * 邮箱
   */
  email?: string | null;
  /**
   * 用户名
   */
  username?: string | null;
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
  roles?: Role[] | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
