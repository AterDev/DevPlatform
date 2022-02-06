import { FilterBase } from '../filter-base.model';
import { NewsSource } from '../enum/news-source.model';
import { NewsType } from '../enum/news-type.model';
import { TechType } from '../enum/tech-type.model';
import { Status } from '../enum/status.model';
export interface ThirdNewsFilter extends FilterBase {
  title?: string | null;
  type?: NewsSource | null;
  newsType?: NewsType | null;
  techType?: TechType | null;
  /**
   * 状态
   */
  status?: Status | null;

}
