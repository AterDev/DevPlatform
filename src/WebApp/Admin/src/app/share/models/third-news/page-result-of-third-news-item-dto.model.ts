import { ThirdNewsItemDto } from '../third-news/third-news-item-dto.model';
export interface PageResultOfThirdNewsItemDto {
  count: number;
  data?: ThirdNewsItemDto[] | null;
  pageIndex: number;

}
