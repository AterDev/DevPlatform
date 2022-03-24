import { LibraryItemDto } from '../library/library-item-dto.model';
export interface PageResultOfLibraryItemDto {
  count: number;
  data?: LibraryItemDto[] | null;
  pageIndex: number;

}
