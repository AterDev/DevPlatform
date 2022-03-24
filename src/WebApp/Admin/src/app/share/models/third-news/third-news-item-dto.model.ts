import { NewsSource } from '../enum/news-source.model';
import { NewsType } from '../enum/news-type.model';
import { TechType } from '../enum/tech-type.model';
import { Status } from '../enum/status.model';
export interface ThirdNewsItemDto {
  authorName?: string | null;
  authorAvatar?: string | null;
  title: string;
  url?: string | null;
  thumbnailUrl?: string | null;
  provider?: string | null;
  datePublished?: Date | null;
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
  /**
   * 0 = Default
1 = Normal
2 = Publish
3 = Focus
   */
  techType?: TechType | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
