import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
export interface UserInfo extends EntityBase {
  account?: string | null;
  accountId: string;
  realName?: string | null;
  nickName?: string | null;
  identityType?: string | null;
  identityCode?: string | null;
  birthday?: Date | null;
  address?: string | null;
  country?: string | null;
  province?: string | null;
  city?: string | null;
  county?: string | null;
  street?: string | null;
  addressDetail?: string | null;
  wxOpenId?: string | null;
  wxAvatar?: string | null;
  wxUnionId?: string | null;

}
