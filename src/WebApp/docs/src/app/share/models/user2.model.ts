import { Account } from './account.model';
import { RepositoryPermissions } from './repository-permissions.model';
export interface User2 extends Account {
  permissions?: RepositoryPermissions | null;
  /**
   * Whether or not the user is an administrator of the site
   */
  siteAdmin: boolean;
  /**
   * When the user was suspended, if at all (GitHub Enterprise)
   */
  suspendedAt?: Date | null;
  /**
   * Whether or not the user is currently suspended
   */
  suspended: boolean;
  /**
   * LDAP Binding (GitHub Enterprise only)
   */
  ldapDistinguishedName?: string | null;
  /**
   * Date the user account was updated.
   */
  updatedAt: Date;

}
