import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
import { LibraryCatalog } from '../library-catalog/library-catalog.model';
import { CodeSnippet } from '../code-snippet/code-snippet.model';
export interface Library extends EntityBase {
  namespace: string;
  description?: string | null;
  language?: string | null;
  isValid: boolean;
  isPublic: boolean;
  user?: User | null;
  catalog?: LibraryCatalog | null;
  snippets?: CodeSnippet[] | null;

}
