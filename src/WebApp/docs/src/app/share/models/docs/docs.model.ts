import { EntityBase } from '../entity-base.model';
import { DocsCatalog } from '../docs-catalog/docs-catalog.model';
export interface Docs extends EntityBase {
  name: string;
  content?: string | null;
  /**
   * 排序
   */
  sort: number;
  /**
   * git url
   */
  gitUrl?: string | null;
  gitSha?: string | null;
  language: string;
  docsCatalog?: DocsCatalog | null;

}
