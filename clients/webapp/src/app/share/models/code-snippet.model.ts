import { BaseDB } from './base-db.model';
import { Library } from './library.model';
import { Language } from './language.model';
import { CodeType } from './code-type.model';
export interface CodeSnippet extends BaseDB {
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
   * 所属类库
   */
  library?: Library | null;
  /**
   * 语言类型
   */
  language?: Language;
  /**
   * 类型
   */
  codeType?: CodeType;

}
