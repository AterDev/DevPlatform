using System;
using System.Collections.Generic;
using OpenIddict.Abstractions;

namespace IdentityServer;

public partial class OpenIddictApplication: OpenIddictApplicationDescriptor
{

    public OpenIddictApplication()
    {
        OpenIddictAuthorizations = new HashSet<OpenIddictAuthorization>();
        OpenIddictTokens = new HashSet<OpenIddictToken>();
    }

    public Guid Id { get; set; }
    public string? ConcurrencyToken { get; set; }
    public virtual ICollection<OpenIddictAuthorization> OpenIddictAuthorizations { get; set; }
    public virtual ICollection<OpenIddictToken> OpenIddictTokens { get; set; }
}
