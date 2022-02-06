import { EntityBase } from '../entity-base.model';
import { NewsSource } from '../enum/news-source.model';
import { NewsType } from '../enum/news-type.model';
import { NewsTags } from '../news-tags/news-tags.model';
import { TechType } from '../enum/tech-type.model';
export interface ThirdNews extends EntityBase {
  authorName?: string | null;
  authorAvatar?: string | null;
  title: string;
  description?: string | null;
  url?: string | null;
  thumbnailUrl?: string | null;
  provider?: string | null;
  datePublished?: Date | null;
  content?: string | null;
  category?: string | null;
  identityId?: string | null;
  /**
   * 0 = News
1 = Tweet
2 = Weibo
3 = Rss
   */
  type?: NewsSource | null;
  /**
   * 0 = Default
1 = Company
2 = OpenSource
3 = LanguageAndFramework
4 = DataAndAI
5 = Else
   */
  newsType?: NewsType | null;
  newsTags?: NewsTags[] | null;
  /**
   * 0 = Default
1 = Normal
2 = Publish
3 = Focus
   */
  techType?: TechType | null;

}
