import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { DocsUpdateDto } from '../models/docs/docs-update-dto.model';
import { DocsFilter } from '../models/docs/docs-filter.model';
import { Docs } from '../models/docs/docs.model';
import { BatchUpdateOfDocsUpdateDto } from '../models/docs/batch-update-of-docs-update-dto.model';
import { PageResultOfDocsItemDto } from '../models/docs/page-result-of-docs-item-dto.model';

/**
 * 文档
 */
@Injectable({ providedIn: 'root' })
export class DocsService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data DocsUpdateDto[]
   */
  addIn(id: string, data: DocsUpdateDto[]): Observable<number> {
    const url = `/api/Docs/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<Docs> {
    const url = `/api/Docs/${id}`;
    return this.request<Docs>('get', url);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data DocsUpdateDto
   */
  update(id: string, data: DocsUpdateDto): Observable<Docs> {
    const url = `/api/Docs/${id}`;
    return this.request<Docs>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Docs/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 分页筛选
   * @param data DocsFilter
   */
  filter(data: DocsFilter): Observable<PageResultOfDocsItemDto> {
    const url = `/api/Docs/filter`;
    return this.request<PageResultOfDocsItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data Docs
   */
  add(data: Docs): Observable<Docs> {
    const url = `/api/Docs`;
    return this.request<Docs>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/Docs`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfDocsUpdateDto
   */
  batchUpdate(data: BatchUpdateOfDocsUpdateDto): Observable<number> {
    const url = `/api/Docs`;
    return this.request<number>('put', url, data);
  }

}
