import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CommentAddDto } from '../share/models/comment-add-dto.model';
import { CommentFilter } from '../share/models/comment-filter.model';
import { CommentUpdateDto } from '../share/models/comment-update-dto.model';
import { Comment } from '../share/models/comment.model';
import { PageResultOfCommentDto } from '../share/models/page-result-of-comment-dto.model';

/**
 * 评论
 */
@Injectable({ providedIn: 'root' })
export class CommentService extends BaseService {

  /**
   * 添加Comment
   * @param data CommentAddDto
   */
  add(data: CommentAddDto): Observable<Comment> {
    const url = `/api/Comment`;
    return this.request<Comment>('post', url, data);
  }

  /**
   * 分页筛选Comment
   * @param data CommentFilter
   */
  filter(data: CommentFilter): Observable<PageResultOfCommentDto> {
    const url = `/api/Comment/filter`;
    return this.request<PageResultOfCommentDto>('post', url, data);
  }

  /**
   * 更新Comment
   * @param id string
   * @param data CommentUpdateDto
   */
  update(id: string, data: CommentUpdateDto): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('put', url, data);
  }

  /**
   * 删除Comment
   * @param id string
   */
  delete(id: string): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('delete', url);
  }

  /**
   * 获取Comment详情
   * @param id string
   */
  getDetail(id: string): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('get', url);
  }



}
