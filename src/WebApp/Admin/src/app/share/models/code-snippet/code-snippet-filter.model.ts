import { FilterBase } from '../filter-base.model';
import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
import { Status } from '../enum/status.model';
export interface CodeSnippetFilter extends FilterBase {
  /**
   * 实体名称
   */
  name?: string | null;
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
  libraryId?: string | null;

}
