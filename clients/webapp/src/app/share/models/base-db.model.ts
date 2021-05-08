import { Status } from './status.model';
/**
 * 数据加基础字段模型
 */
export interface BaseDB {
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
