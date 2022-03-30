import { FilterBase } from '../filter-base.model';
import { Status } from '../enum/status.model';
export interface RoleFilter extends FilterBase {
  name?: string | null;
  concurrencyStamp?: string | null;
  status?: Status | null;

}
