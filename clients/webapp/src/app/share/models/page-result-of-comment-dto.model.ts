/**
 * 带分页的结果
 */
export interface PageResultOfCommentDto {
  count: number;
  data?: CommentDto[] | null;
  pageIndex: number;

}
