import { ArticleCatalog } from './article-catalog.model';
import { Status } from './status.model';
export interface ArticleCatalogDto {
  /**
   * 父目录
   */
  parent?: ArticleCatalog | null;
  /**
   * 所属用户
   */
  name?: string | null;
  type?: string | null;
  sort: number;
  level: number;
  parentId: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
