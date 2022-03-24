import { EntityBase } from '../entity-base.model';
import { ThirdNews } from '../third-news/third-news.model';
export interface NewsTags extends EntityBase {
  name: string;
  color?: string | null;
  thirdNews?: ThirdNews | null;

}
