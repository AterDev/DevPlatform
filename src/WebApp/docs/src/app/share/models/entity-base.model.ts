import { Status } from './enum/status.model';
export interface EntityBase {
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
