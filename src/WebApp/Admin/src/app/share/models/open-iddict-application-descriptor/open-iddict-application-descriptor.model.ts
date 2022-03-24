/**
 * Represents an OpenIddict application descriptor.
 */
export interface OpenIddictApplicationDescriptor {
  /**
   * Gets or sets the client identifier associated with the application.
   */
  clientId?: string | null;
  /**
   * Gets or sets the client secret associated with the application.
Note: depending on the application manager used when creating it,
this property may be hashed or encrypted for security reasons.
   */
  clientSecret?: string | null;
  /**
   * Gets or sets the consent type associated with the application.
   */
  consentType?: string | null;
  /**
   * Gets or sets the display name associated with the application.
   */
  displayName?: string | null;
  /**
   * Gets the localized display names associated with the application.
   */
  displayNames: string;
  /**
   * Gets the permissions associated with the application.
   */
  permissions: string[];
  /**
   * Gets the logout callback URLs associated with the application.
   */
  postLogoutRedirectUris: string[];
  /**
   * Gets the additional properties associated with the application.
   */
  properties: string;
  /**
   * Gets the callback URLs associated with the application.
   */
  redirectUris: string[];
  /**
   * Gets the requirements associated with the application.
   */
  requirements: string[];
  /**
   * Gets or sets the application type associated with the application.
   */
  type?: string | null;

}
