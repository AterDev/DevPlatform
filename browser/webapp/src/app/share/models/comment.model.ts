import { BaseDB } from './base-db.model';
import { Article } from './article.model';
import { Account } from './account.model';
export interface Comment extends BaseDB {
  article?: Article | null;
  account?: Account | null;
  /**
   * 评论内容
   */
  content?: string | null;

}
