import { EntityBase } from '../entity-base.model';
import { Article } from '../article/article.model';
import { User } from '../user/user.model';
export interface Comment extends EntityBase {
  article?: Article | null;
  account?: User | null;
  content?: string | null;

}
