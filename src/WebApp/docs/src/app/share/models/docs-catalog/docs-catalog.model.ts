import { EntityBase } from '../entity-base.model';
import { Docs } from '../docs/docs.model';
export interface DocsCatalog extends EntityBase {
  /**
   * 父节点
   */
  parent?: DocsCatalog | null;
  /**
   * 子节点
   */
  children?: DocsCatalog[] | null;
  name: string;
  sort: number;
  /**
   * git url
   */
  gitUrl?: string | null;
  gitSha?: string | null;
  language: string;
  docs?: Docs[] | null;

}
