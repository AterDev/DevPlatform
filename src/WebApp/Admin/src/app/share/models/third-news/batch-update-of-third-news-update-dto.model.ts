import { ThirdNewsUpdateDto } from '../third-news/third-news-update-dto.model';
export interface BatchUpdateOfThirdNewsUpdateDto {
  ids: string[];
  updateDto?: string | null;

}
