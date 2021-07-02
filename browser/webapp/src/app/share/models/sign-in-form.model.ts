/**
 * 登录模型
 */
export interface SignInForm {
  /**
   * 用户名/手机号/邮箱
   */
  username: string;
  password: string;
  /**
   * 验证码
   */
  captcha: string;

}
