/**
 * 带分页的结果
 */
export interface PageResultOfRoleDto {
  count: number;
  data?: RoleDto[] | null;
  pageIndex: number;

}
