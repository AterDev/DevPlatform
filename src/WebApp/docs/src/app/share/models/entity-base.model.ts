import { Status } from './enum/status.model';
export interface EntityBase {
  id: string;
  /**
   * 状态
   */
  status?: Status | null;
  createdTime: Date;
  updatedTime: Date;

}
