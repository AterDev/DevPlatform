import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
import { Status } from '../enum/status.model';
/**
 * 代码片段
 */
export interface CodeSnippetUpdateDto {
  /**
   * 实体名称
   */
  name?: string | null;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 实体定义内容
   */
  content?: string | null;
  /**
   * 语言类型
   */
  language?: Language | null;
  /**
   * 类型
   */
  codeType?: CodeType | null;
  /**
   * 状态
   */
  status?: Status | null;

}
