import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CodeSnippetFilter } from '../models/code-snippet/code-snippet-filter.model';
import { CodeSnippet } from '../models/code-snippet/code-snippet.model';
import { BatchUpdateOfCodeSnippetUpdateDto } from '../models/code-snippet/batch-update-of-code-snippet-update-dto.model';
import { CodeSnippetUpdateDto } from '../models/code-snippet/code-snippet-update-dto.model';
import { PageResultOfCodeSnippetItemDto } from '../models/code-snippet/page-result-of-code-snippet-item-dto.model';

/**
 * 代码片段
 */
@Injectable({ providedIn: 'root' })
export class CodeSnippetService extends BaseService {
  /**
   * 分页筛选
   * @param data CodeSnippetFilter
   */
  filter(data: CodeSnippetFilter): Observable<PageResultOfCodeSnippetItemDto> {
    const url = `/api/CodeSnippet/filter`;
    return this.request<PageResultOfCodeSnippetItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data CodeSnippet
   */
  add(data: CodeSnippet): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet`;
    return this.request<CodeSnippet>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/CodeSnippet`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfCodeSnippetUpdateDto
   */
  batchUpdate(data: BatchUpdateOfCodeSnippetUpdateDto): Observable<number> {
    const url = `/api/CodeSnippet`;
    return this.request<number>('put', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data CodeSnippetUpdateDto
   */
  update(id: string, data: CodeSnippetUpdateDto): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('get', url);
  }

}
