import { EntityBase } from '../entity-base.model';
export interface TagLibrary extends EntityBase {
  type: string;
  name: string;
  color?: string | null;
  style?: string | null;

}
