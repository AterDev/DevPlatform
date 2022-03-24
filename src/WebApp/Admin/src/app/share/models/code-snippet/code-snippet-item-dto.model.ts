import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
import { Status } from '../enum/status.model';
/**
 * 代码片段
 */
export interface CodeSnippetItemDto {
  /**
   * 实体名称
   */
  name: string;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 语言类型
   */
  language?: Language;
  /**
   * 类型
   */
  codeType?: CodeType;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
