import { WebConfigItemDto } from '../web-config/web-config-item-dto.model';
export interface PageResultOfWebConfigItemDto {
  count: number;
  data?: WebConfigItemDto[] | null;
  pageIndex: number;

}
