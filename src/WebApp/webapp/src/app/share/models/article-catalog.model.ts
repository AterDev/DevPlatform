import { BaseDB } from './base-db.model';
import { Article } from './article.model';
import { Account } from './account.model';
export interface ArticleCatalog extends BaseDB {
  name?: string | null;
  type?: string | null;
  sort: number;
  level: number;
  /**
   * 该目录的文章
   */
  articles?: Article[] | null;
  /**
   * 父目录
   */
  parent?: ArticleCatalog | null;
  parentId?: string | null;
  /**
   * 所属用户
   */
  account?: Account | null;
  accountId: string;
  /**
   * 子目录
   */
  catalogs?: ArticleCatalog[] | null;

}
