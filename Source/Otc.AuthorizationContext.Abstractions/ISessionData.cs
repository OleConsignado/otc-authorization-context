using System;
using System.Collections.Generic;
using System.Text;

namespace Otc.SessionContext.Abstractions
{
    [Obsolete("Otc.SessionContext.Abstractions.ISessionData now is Otc.AuthorizationContext.Abstractions.IAuthorizationData. We strongly encourage you to migrate from Otc.SessionContext.Abstractions to Otc.AuthorizationContext.Abstractions.")]
    public interface ISessionData
    {
        string UserId { get; }
    }
}
