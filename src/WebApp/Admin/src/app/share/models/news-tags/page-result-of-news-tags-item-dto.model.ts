import { NewsTagsItemDto } from '../news-tags/news-tags-item-dto.model';
export interface PageResultOfNewsTagsItemDto {
  count: number;
  data?: NewsTagsItemDto[] | null;
  pageIndex: number;

}
