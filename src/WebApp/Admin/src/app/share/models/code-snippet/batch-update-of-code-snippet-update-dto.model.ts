import { CodeSnippetUpdateDto } from '../code-snippet/code-snippet-update-dto.model';
export interface BatchUpdateOfCodeSnippetUpdateDto {
  ids: string[];
  /**
   * 代码片段
   */
  updateDto?: CodeSnippetUpdateDto | null;

}
