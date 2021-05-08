import { ArticleCatalog } from './article-catalog.model';
import { Status } from './status.model';
export interface ArticleCatalogUpdateDto {
  /**
   * 父目录
   */
  parent?: ArticleCatalog | null;
  name?: string | null;
  type?: string | null;
  sort: number;
  level: number;
  parentId: string;
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;

}
