import { IdentityRoleOfGuid } from '../identity-role-of-guid/identity-role-of-guid.model';
import { Status } from '../enum/status.model';
export interface Role extends IdentityRoleOfGuid {
  id: string;
  name: string;
  normalizedName?: string | null;
  concurrencyStamp: string;
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
