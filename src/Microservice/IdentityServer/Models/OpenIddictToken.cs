using System;
using System.Collections.Generic;

namespace IdentityServer;

public partial class OpenIddictToken
{
    public Guid Id { get; set; }
    public Guid? ApplicationId { get; set; }
    public Guid? AuthorizationId { get; set; }
    public string? ConcurrencyToken { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? Payload { get; set; }
    public string? Properties { get; set; }
    public DateTime? RedemptionDate { get; set; }
    public string? ReferenceId { get; set; }
    public string? Status { get; set; }
    public string? Subject { get; set; }
    public string? Type { get; set; }

    public virtual OpenIddictApplication? Application { get; set; }
    public virtual OpenIddictAuthorization? Authorization { get; set; }
}
