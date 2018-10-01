using System;

namespace Otc.SessionContext.Abstractions
{
    [Obsolete("Otc.SessionContext.Abstractions.ISessionSerializer now is Otc.AuthorizationContext.Abstractions.IAuthorizationDataSerializer. We strongly encourage you to migrate from Otc.SessionContext.Abstractions to Otc.AuthorizationContext.Abstractions.")]
    public interface ISessionSerializer<TSessionData> where TSessionData : ISessionData
    {
        string Serialize(TSessionData sessionData);
    }
}
