/**
 * A plan (either paid or free) for a particular user
 */
export interface Plan {
  /**
   * The number of collaborators allowed with this plan.
   */
  collaborators: number;
  /**
   * The name of the plan.
   */
  name?: string | null;
  /**
   * The number of private repositories allowed with this plan.
   */
  privateRepos: number;
  /**
   * The amount of disk space allowed with this plan.
   */
  space: number;
  /**
   * The billing email for the organization. Only has a value in response to editing an organization.
   */
  billingEmail?: string | null;

}
