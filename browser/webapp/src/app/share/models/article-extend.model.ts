import { BaseDB } from './base-db.model';
export interface ArticleExtend extends BaseDB {
  content?: string | null;

}
