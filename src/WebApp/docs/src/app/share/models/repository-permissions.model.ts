export interface RepositoryPermissions {
  /**
   * Whether the current user has administrative permissions
   */
  admin: boolean;
  /**
   * Whether the current user has push permissions
   */
  push: boolean;
  /**
   * Whether the current user has pull permissions
   */
  pull: boolean;

}
