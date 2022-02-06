import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
export interface LibraryCatalog extends EntityBase {
  name: string;
  type?: string | null;
  sort: number;
  level: number;
  parent?: LibraryCatalog | null;
  parentId?: string | null;
  account?: string | null;
  accountId: string;
  catalogs?: LibraryCatalog[] | null;

}
