﻿using System;
using System.Collections.Generic;

namespace EntityFramework.IdentityModels;

public partial class OpenIddictToken
{
    public string Id { get; set; } = null!;
    public string? ApplicationId { get; set; }
    public string? AuthorizationId { get; set; }
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
