import { EntityBase } from '../entity-base.model';
export interface User extends EntityBase {
  userName: string;
  password: string;
  avatar?: string | null;

}
