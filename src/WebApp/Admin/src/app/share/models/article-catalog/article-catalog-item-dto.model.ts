import { Status } from '../enum/status.model';
export interface ArticleCatalogItemDto {
  name: string;
  type?: string | null;
  sort: number;
  level: number;
  parentId?: string | null;
  accountId: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
