import { AccountType } from './enum/account-type.model';
import { Plan } from './plan.model';
/**
 * Base class for a GitHub account, most often either a User or Organization.
 */
export interface Account {
  /**
   * URL of the account's avatar.
   */
  avatarUrl?: string | null;
  /**
   * The account's bio.
   */
  bio?: string | null;
  /**
   * URL of the account's blog.
   */
  blog?: string | null;
  /**
   * Number of collaborators the account has.
   */
  collaborators?: number | null;
  /**
   * Company the account works for.
   */
  company?: string | null;
  /**
   * Date the account was created.
   */
  createdAt: Date;
  /**
   * Amount of disk space the account is using.
   */
  diskUsage?: number | null;
  /**
   * The account's email.
   */
  email?: string | null;
  /**
   * Number of followers the account has.
   */
  followers: number;
  /**
   * Number of other users the account is following.
   */
  following: number;
  /**
   * Indicates whether the account is currently hireable.
   */
  hireable?: boolean | null;
  /**
   * The HTML URL for the account on github.com (or GitHub Enterprise).
   */
  htmlUrl?: string | null;
  /**
   * The account's system-wide unique Id.
   */
  id: number;
  /**
   * GraphQL Node Id
   */
  nodeId?: string | null;
  /**
   * The account's geographic location.
   */
  location?: string | null;
  /**
   * The account's login.
   */
  login?: string | null;
  /**
   * The account's full name.
   */
  name?: string | null;
  /**
   * The type of account associated with this entity
   */
  type?: AccountType | null;
  /**
   * Number of private repos owned by the account.
   */
  ownedPrivateRepos: number;
  /**
   * Plan the account pays for.
   */
  plan?: Plan | null;
  /**
   * Number of private gists the account has created.
   */
  privateGists?: number | null;
  /**
   * Number of public gists the account has created.
   */
  publicGists: number;
  /**
   * Number of public repos the account owns.
   */
  publicRepos: number;
  /**
   * Total number of private repos the account owns.
   */
  totalPrivateRepos: number;
  /**
   * The account's API URL.
   */
  url?: string | null;

}
