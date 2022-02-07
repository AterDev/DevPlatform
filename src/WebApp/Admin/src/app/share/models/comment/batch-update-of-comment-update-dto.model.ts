import { CommentUpdateDto } from '../comment/comment-update-dto.model';
export interface BatchUpdateOfCommentUpdateDto {
  ids: string[];
  updateDto?: CommentUpdateDto | null;

}
