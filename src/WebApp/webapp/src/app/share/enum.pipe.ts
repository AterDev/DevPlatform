import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enum'
})
export class EnumPipe implements PipeTransform {
  transform(value: unknown, type: string): unknown {
    let result = '';
    switch (type) {
      // 性别
      case 'sex':
        switch (value) {
          case 0:
            result = '男';
            break;
          case 0:
            result = '女';
            break;

          default:
            result = '其他';
            break;
        }
        break;
      default:
        break;
    }

    return result;
  }
}
