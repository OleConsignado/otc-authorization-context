using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Otc.SessionContext.Abstractions;
using System;
using System.Linq;
using System.Security.Claims;

namespace Otc.SessionContext.AspNetCore.Jwt
{
    public class SessionContext<TSessionData> : ISessionContext<TSessionData>
        where TSessionData : ISessionData
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        private TSessionData sessionData;

        public TSessionData SessionData
        {
            get
            {
                if (sessionData == null)
                {
                    var claimsIdentity = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;

                    if (claimsIdentity == null)
                    {
                        throw new UnauthorizedAccessException();
                    }

                    var sessionData = claimsIdentity.Claims.Single(c => c.Type == JwtConfiguration.SessionDataJwtTypeName).Value;
                    this.sessionData = JsonConvert.DeserializeObject<TSessionData>(sessionData);
                }

                return sessionData;
            }
        }
    }
}
