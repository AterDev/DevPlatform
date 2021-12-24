import { Status } from './status.model';
export interface SignInDto {
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
  /**
   * 头像url
   */
  avatar?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;
  token?: string | null;
  roleName?: string | null;

}
