export interface WebConfigAddDto {
  id?: string | null;
  /**
   * 网站名称
   */
  webSiteName?: string | null;
  description?: string | null;
  /**
   * github 用户名
   */
  githubUser?: string | null;
  /**
   * github PAT
   */
  githubPAT?: string | null;
  /**
   * 同步的仓库id
   */
  repositoryId?: number | null;

}
