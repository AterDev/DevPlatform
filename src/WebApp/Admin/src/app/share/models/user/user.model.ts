import { IdentityUserOfGuid } from '../identity-user-of-guid/identity-user-of-guid.model';
import { Status } from '../enum/status.model';
import { UserInfo } from '../user-info/user-info.model';
import { Article } from '../article/article.model';
import { ArticleCatalog } from '../article-catalog/article-catalog.model';
import { Comment } from '../comment/comment.model';
export interface User extends IdentityUserOfGuid {
  id: string;
  userName: string;
  normalizedUserName?: string | null;
  email: string;
  normalizedEmail?: string | null;
  emailConfirmed: boolean;
  passwordHash: string;
  securityStamp?: string | null;
  concurrencyStamp: string;
  phoneNumber?: string | null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd?: Date | null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  lastLoginTime?: Date | null;
  isDeleted: boolean;
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
  avatar?: string | null;
  extend?: UserInfo | null;
  articles?: Article[] | null;
  articleCatalogs?: ArticleCatalog[] | null;
  comments?: Comment[] | null;

}
