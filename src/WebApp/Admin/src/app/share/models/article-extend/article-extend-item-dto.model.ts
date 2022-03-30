import { Status } from '../enum/status.model';
/**
 * 文章扩展
 */
export interface ArticleExtendItemDto {
  articleId: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
