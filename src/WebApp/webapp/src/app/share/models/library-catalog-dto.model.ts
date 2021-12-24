import { LibraryCatalog } from './library-catalog.model';
import { Status } from './status.model';
export interface LibraryCatalogDto {
  name?: string | null;
  type?: string | null;
  sort: number;
  level: number;
  parent?: LibraryCatalog | null;
  /**
   * 所属用户
   */
  accountId: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
