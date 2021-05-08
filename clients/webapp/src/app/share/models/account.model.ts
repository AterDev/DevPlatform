import { BaseDB } from './base-db.model';
import { AccountExtend } from './account-extend.model';
export interface Account extends BaseDB {
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
  phone?: string | null;
  phoneConfirm: boolean;
  emailConfirm: boolean;
  /**
   * 头像url
   */
  avatar?: string | null;
  extend?: AccountExtend | null;
  roles?: Role[] | null;
  /**
   * 文章
   */
  articles?: Article[] | null;
  /**
   * 文章目录
   */
  articleCatalogs?: ArticleCatalog[] | null;
  /**
   * 评论
   */
  comments?: Comment[] | null;

}
