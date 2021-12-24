/**
 * 辅助类
 */
export class Util {
  constructor() {

  }
  /**
   * 枚举转 K/V
   * @param enumType 枚举类型
   * @returns Array
   */
  public static enumToArray<T>(enumType: any): KeyValue<T>[] {
    const keyValue: KeyValue<T>[] = [];
    let keys = Object.keys(enumType);
    // 过滤 数值型键
    keys = keys.filter(v => isNaN(parseInt(v, 10)));
    keys.forEach((v) => {
      const item: KeyValue<T> = { key: v, value: enumType[v] };
      keyValue.push(item);
    });
    return keyValue;
  }
}


export interface KeyValue<T> {
  key: string;
  value: T;
}
