import { User2 } from './user2.model';
import { RepositoryPermissions } from './repository-permissions.model';
import { LicenseMetadata } from './license-metadata.model';
import { RepositoryVisibility } from './enum/repository-visibility.model';
export interface Repository {
  url?: string | null;
  htmlUrl?: string | null;
  cloneUrl?: string | null;
  gitUrl?: string | null;
  sshUrl?: string | null;
  svnUrl?: string | null;
  mirrorUrl?: string | null;
  id: number;
  /**
   * GraphQL Node Id
   */
  nodeId?: string | null;
  owner?: User2 | null;
  name?: string | null;
  fullName?: string | null;
  isTemplate: boolean;
  description?: string | null;
  homepage?: string | null;
  language?: string | null;
  private: boolean;
  fork: boolean;
  forksCount: number;
  stargazersCount: number;
  watchersCount: number;
  defaultBranch?: string | null;
  openIssuesCount: number;
  pushedAt?: Date | null;
  createdAt: Date;
  updatedAt: Date;
  permissions?: RepositoryPermissions | null;
  parent?: Repository | null;
  source?: Repository | null;
  license?: LicenseMetadata | null;
  hasIssues: boolean;
  hasWiki: boolean;
  hasDownloads: boolean;
  allowRebaseMerge?: boolean | null;
  allowSquashMerge?: boolean | null;
  allowMergeCommit?: boolean | null;
  hasPages: boolean;
  subscribersCount: number;
  size: number;
  archived: boolean;
  topics?: string[] | null;
  deleteBranchOnMerge?: boolean | null;
  visibility?: RepositoryVisibility | null;

}
