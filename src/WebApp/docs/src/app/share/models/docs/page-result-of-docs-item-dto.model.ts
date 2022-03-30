import { DocsItemDto } from '../docs/docs-item-dto.model';
export interface PageResultOfDocsItemDto {
  count: number;
  data?: DocsItemDto[] | null;
  pageIndex: number;

}
