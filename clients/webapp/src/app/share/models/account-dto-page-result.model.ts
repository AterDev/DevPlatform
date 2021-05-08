import { AccountDto } from './account-dto.model';
export interface AccountDtoPageResult {
  count: number;
  data?: AccountDto[] | null;
  pageIndex: number;

}
