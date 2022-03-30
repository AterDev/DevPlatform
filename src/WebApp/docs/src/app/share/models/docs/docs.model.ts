import { EntityBase } from '../entity-base.model';
import { DocsCatalog } from '../docs-catalog/docs-catalog.model';
export interface Docs extends EntityBase {
  name: string;
  content?: string | null;
  docsCatalog?: DocsCatalog | null;

}
