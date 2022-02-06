import { EntityBase } from '../entity-base.model';
import { Article } from '../article/article.model';
import { User } from '../user/user.model';
export interface ArticleCatalog extends EntityBase {
  name: string;
  type?: string | null;
  sort: number;
  level: number;
  articles?: Article[] | null;
  parent?: ArticleCatalog | null;
  parentId?: string | null;
  account?: string | null;
  accountId: string;
  catalogs?: ArticleCatalog[] | null;

}
