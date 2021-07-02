import { CommentDto } from './comment-dto.model';
/**
 * 带分页的结果
 */
export interface PageResultOfCommentDto {
  count: number;
  data?: CommentDto[] | null;
  pageIndex: number;

}
