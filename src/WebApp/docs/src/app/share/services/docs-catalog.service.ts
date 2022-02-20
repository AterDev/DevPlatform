import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { DocsCatalogFilter } from '../models/docs-catalog/docs-catalog-filter.model';
import { DocsCatalog } from '../models/docs-catalog/docs-catalog.model';
import { BatchUpdateOfDocsCatalogUpdateDto } from '../models/docs-catalog/batch-update-of-docs-catalog-update-dto.model';
import { DocsCatalogAddDto } from '../models/docs-catalog/docs-catalog-add-dto.model';
import { DocsCatalogUpdateDto } from '../models/docs-catalog/docs-catalog-update-dto.model';
import { PageResultOfDocsCatalogItemDto } from '../models/docs-catalog/page-result-of-docs-catalog-item-dto.model';
import { DocsCatalogTreeItemDto } from '../models/docs-catalog-tree/docs-catalog-tree-item-dto.model';

/**
 * 文档目录
 */
@Injectable({ providedIn: 'root' })
export class DocsCatalogService extends BaseService {
  /**
   * 分页筛选
   * @param data DocsCatalogFilter
   */
  filter(data: DocsCatalogFilter): Observable<PageResultOfDocsCatalogItemDto> {
    const url = `/api/DocsCatalog/filter`;
    return this.request<PageResultOfDocsCatalogItemDto>('post', url, data);
  }

  /**
   * 获取树形结构
   */
  getTree(): Observable<DocsCatalogTreeItemDto[]> {
    const url = `/api/DocsCatalog/tree`;
    return this.request<[]>('get', url);
  }

  /**
   * 添加
   * @param data DocsCatalog
   */
  add(data: DocsCatalog): Observable<DocsCatalog> {
    const url = `/api/DocsCatalog`;
    return this.request<DocsCatalog>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/DocsCatalog`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfDocsCatalogUpdateDto
   */
  batchUpdate(data: BatchUpdateOfDocsCatalogUpdateDto): Observable<number> {
    const url = `/api/DocsCatalog`;
    return this.request<number>('put', url, data);
  }

  /**
   * 添加文档目录
   * @param data DocsCatalogAddDto
   */
  addIn(data: DocsCatalogAddDto): Observable<DocsCatalog> {
    const url = `/api/DocsCatalog/add`;
    return this.request<DocsCatalog>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data DocsCatalogUpdateDto
   */
  update(id: string, data: DocsCatalogUpdateDto): Observable<DocsCatalog> {
    const url = `/api/DocsCatalog/${id}`;
    return this.request<DocsCatalog>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/DocsCatalog/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<DocsCatalog> {
    const url = `/api/DocsCatalog/${id}`;
    return this.request<DocsCatalog>('get', url);
  }

}
