import { CodeSnippetDto } from './code-snippet-dto.model';
/**
 * 带分页的结果
 */
export interface PageResultOfCodeSnippetDto {
  count: number;
  data?: CodeSnippetDto[] | null;
  pageIndex: number;

}