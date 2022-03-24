import { EntityBase } from '../entity-base.model';
import { Article } from '../article/article.model';
export interface ArticleExtend extends EntityBase {
  article?: Article | null;
  articleId: string;
  content: string;

}
