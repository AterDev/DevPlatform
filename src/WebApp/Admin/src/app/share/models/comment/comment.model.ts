import { EntityBase } from '../entity-base.model';
import { Article } from '../article/article.model';
import { User } from '../user/user.model';
export interface Comment extends EntityBase {
  article?: string | null;
  account?: string | null;
  content?: string | null;

}
