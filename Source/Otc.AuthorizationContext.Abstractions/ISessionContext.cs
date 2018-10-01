using System;
using System.Collections.Generic;
using System.Text;

namespace Otc.SessionContext.Abstractions
{
    [Obsolete("Otc.SessionContext.Abstractions.ISessionContext now is Otc.AuthorizationContext.Abstractions.IAuthorizationContext. We strongly encourage you to migrate from Otc.SessionContext.Abstractions to Otc.AuthorizationContext.Abstractions.")]
    public interface ISessionContext<TSessionData> where TSessionData : ISessionData
    {
        TSessionData SessionData { get; }
    }
}
