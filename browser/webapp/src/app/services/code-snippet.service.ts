import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CodeSnippetAddDto } from '../share/models/code-snippet-add-dto.model';
import { CodeSnippetFilter } from '../share/models/code-snippet-filter.model';
import { CodeSnippetUpdateDto } from '../share/models/code-snippet-update-dto.model';
import { CodeSnippet } from '../share/models/code-snippet.model';
import { PageResultOfCodeSnippetDto } from '../share/models/page-result-of-code-snippet-dto.model';

/**
 * 代码片段
 */
@Injectable({ providedIn: 'root' })
export class CodeSnippetService extends BaseService {

  /**
   * 添加CodeSnippet
   * @param data CodeSnippetAddDto
   */
  add(data: CodeSnippetAddDto): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet`;
    return this.request<CodeSnippet>('post', url, data);
  }

  /**
   * 分页筛选CodeSnippet
   * @param data CodeSnippetFilter
   */
  filter(data: CodeSnippetFilter): Observable<PageResultOfCodeSnippetDto> {
    const url = `/api/CodeSnippet/filter`;
    return this.request<PageResultOfCodeSnippetDto>('post', url, data);
  }

  /**
   * 更新CodeSnippet
   * @param id string
   * @param data CodeSnippetUpdateDto
   */
  update(id: string, data: CodeSnippetUpdateDto): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('put', url, data);
  }

  /**
   * delete
   * @param id string
   */
  delete(id: string): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('delete', url);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('get', url);
  }



}
