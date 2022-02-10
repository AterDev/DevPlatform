import { EntityBase } from '../entity-base.model';
import { ArticleType } from '../enum/article-type.model';
import { User } from '../user/user.model';
import { ArticleExtend } from '../article-extend/article-extend.model';
import { ArticleCatalog } from '../article-catalog/article-catalog.model';
import { Comment } from '../comment/comment.model';
export interface Article extends EntityBase {
  title: string;
  summary?: string | null;
  authorName?: string | null;
  tags?: string | null;
  /**
   * 0 = Transport
1 = Course
2 = News
3 = Tech
4 = Comment
   */
  articleType?: ArticleType | null;
  account?: User | null;
  isPrivate?: boolean | null;
  extend?: ArticleExtend | null;
  catalog?: ArticleCatalog | null;
  comments?: Comment[] | null;

}
