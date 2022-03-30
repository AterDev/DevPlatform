import { Status } from '../enum/status.model';
/**
 * 目录/文件目录 / 自引用
 */
export interface LibraryCatalogItemDto {
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
