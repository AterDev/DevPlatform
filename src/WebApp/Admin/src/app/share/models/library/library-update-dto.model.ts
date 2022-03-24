import { Status } from '../enum/status.model';
/**
 * 模型库
 */
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
  isValid?: boolean | null;
  /**
   * 是否公开
   */
  isPublic?: boolean | null;
  /**
   * 状态
   */
  status?: Status | null;
  userId?: string | null;

}
