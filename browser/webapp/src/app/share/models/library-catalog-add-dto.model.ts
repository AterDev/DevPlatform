import { LibraryCatalog } from './library-catalog.model';
import { Status } from './status.model';
export interface LibraryCatalogAddDto {
  name?: string | null;
  type?: string | null;
  sort: number;
  level: number;
  parent?: LibraryCatalog | null;
  accountId: string;
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;

}
