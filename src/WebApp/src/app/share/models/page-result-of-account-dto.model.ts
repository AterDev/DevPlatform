import { AccountDto } from './account-dto.model';
/**
 * 带分页的结果
 */
export interface PageResultOfAccountDto {
  count: number;
  data?: AccountDto[] | null;
  pageIndex: number;

}
