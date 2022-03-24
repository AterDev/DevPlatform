import { TagLibraryItemDto } from '../tag-library/tag-library-item-dto.model';
export interface PageResultOfTagLibraryItemDto {
  count: number;
  data?: TagLibraryItemDto[] | null;
  pageIndex: number;

}
