import { BaseDB } from './base-db.model';
export interface AccountExtend extends BaseDB {
  /**
   * 真实姓名
   */
  realName?: string | null;
  /**
   * 昵称 
   */
  nickName?: string | null;
  /**
   * 出生日期
   */
  birthday?: Date | null;
  /**
   * 地址
   */
  address?: string | null;
  /**
   * 国家
   */
  country?: string | null;
  /**
   * 省
   */
  province?: string | null;
  /**
   * 市
   */
  city?: string | null;
  /**
   * 区县
   */
  county?: string | null;
  /**
   * 街道
   */
  street?: string | null;
  /**
   * 详情地址:路/小区/楼
   */
  addressDetail?: string | null;
  /**
   * 微信openId
   */
  wxOpenId?: string | null;
  wxAvatar?: string | null;
  wxUnionId?: string | null;

}
