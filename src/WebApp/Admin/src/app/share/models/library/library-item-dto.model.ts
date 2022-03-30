import { Status } from '../enum/status.model';
/**
 * 模型库
 */
export interface LibraryItemDto {
  /**
   * 库命名空间
   */
  namespace: string;
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
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
