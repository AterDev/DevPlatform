import { WebConfigUpdateDto } from '../web-config/web-config-update-dto.model';
export interface BatchUpdateOfWebConfigUpdateDto {
  ids: string[];
  updateDto?: WebConfigUpdateDto | null;

}
