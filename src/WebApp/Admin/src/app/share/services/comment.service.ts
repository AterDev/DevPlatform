import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CommentUpdateDto } from '../models/comment/comment-update-dto.model';
import { CommentFilter } from '../models/comment/comment-filter.model';
import { Comment } from '../models/comment/comment.model';
import { BatchUpdateOfCommentUpdateDto } from '../models/comment/batch-update-of-comment-update-dto.model';
import { PageResultOfCommentItemDto } from '../models/comment/page-result-of-comment-item-dto.model';

/**
 * Comment
 */
@Injectable({ providedIn: 'root' })
export class CommentService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  addIn(id: string, data: []): Observable<number> {
    const url = `/api/Comment/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data CommentUpdateDto
   */
  update(id: string, data: CommentUpdateDto): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Comment/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('get', url);
  }

  /**
   * 分页筛选
   * @param data CommentFilter
   */
  filter(data: CommentFilter): Observable<PageResultOfCommentItemDto> {
    const url = `/api/Comment/filter`;
    return this.request<PageResultOfCommentItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data Comment
   */
  add(data: Comment): Observable<Comment> {
    const url = `/api/Comment`;
    return this.request<Comment>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/Comment`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfCommentUpdateDto
   */
  batchUpdate(data: BatchUpdateOfCommentUpdateDto): Observable<number> {
    const url = `/api/Comment`;
    return this.request<number>('put', url, data);
  }

}
