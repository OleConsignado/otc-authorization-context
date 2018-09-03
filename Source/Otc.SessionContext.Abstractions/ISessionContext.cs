using System;
using System.Collections.Generic;
using System.Text;

namespace Otc.SessionContext.Abstractions
{
    public interface ISessionContext<TSessionData> where TSessionData : ISessionData
    {
        TSessionData SessionData { get; }
    }
}
