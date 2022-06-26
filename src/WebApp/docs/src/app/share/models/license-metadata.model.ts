export interface LicenseMetadata {
  /**
   * The 
   */
  key?: string | null;
  /**
   * GraphQL Node Id
   */
  nodeId?: string | null;
  /**
   * Friendly name of the license.
   */
  name?: string | null;
  /**
   * SPDX license identifier.
   */
  spdxId?: string | null;
  /**
   * URL to retrieve details about a license.
   */
  url?: string | null;
  /**
   * Whether the license is one of the licenses featured on https://choosealicense.com
   */
  featured: boolean;

}
