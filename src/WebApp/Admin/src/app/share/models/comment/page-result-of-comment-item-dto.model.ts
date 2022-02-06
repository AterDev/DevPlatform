import { CommentItemDto } from '../comment/comment-item-dto.model';
export interface PageResultOfCommentItemDto {
  count: number;
  data?: CommentItemDto[] | null;
  pageIndex: number;

}
