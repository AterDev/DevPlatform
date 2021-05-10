import { Language } from './language.model';
import { CodeType } from './code-type.model';
import { Status } from './status.model';
export interface CodeSnippetDto {
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
