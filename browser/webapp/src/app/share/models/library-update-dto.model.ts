import { Status } from './status.model';
export interface LibraryUpdateDto {
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
  /**
   * 状态
   */
  status?: Status;
  updatedTime: Date;

}
