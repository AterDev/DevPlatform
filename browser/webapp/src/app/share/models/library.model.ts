import { BaseDB } from './base-db.model';
import { Account } from './account.model';
import { LibraryCatalog } from './library-catalog.model';
import { CodeSnippet } from './code-snippet.model';
export interface Library extends BaseDB {
  /**
   * 库命名空间
   */
  namespace?: string | null;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 语言类型
   */
  language?: string | null;
  /**
   * 是否有效
   */
  isValid: boolean;
  /**
   * 是否公开
   */
  isPublic: boolean;
  user?: Account | null;
  catalog?: LibraryCatalog | null;
  snippets?: CodeSnippet[] | null;

}
