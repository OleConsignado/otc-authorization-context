using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Otc.AuthorizationContext.Abstractions;
using System;
using System.Linq;
using System.Security.Claims;

namespace Otc.AuthorizationContext.AspNetCore.Jwt
{
    public class AuthorizationContext<TAuthorizationData> : IAuthorizationContext<TAuthorizationData>
        where TAuthorizationData : IAuthorizationData
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizationContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        private TAuthorizationData authorizationData;

        public TAuthorizationData AuthorizationData
        {
            get
            {
                if (authorizationData == null)
                {
                    var claimsIdentity = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;

                    if (claimsIdentity == null)
                    {
                        throw new UnauthorizedAccessException();
                    }

                    var authorizationData = claimsIdentity.Claims.Single(c => c.Type == JwtConfiguration.AuthorizationDataJwtTypeName).Value;
                    this.authorizationData = JsonConvert.DeserializeObject<TAuthorizationData>(authorizationData);
                }

                return authorizationData;
            }
        }
    }

}
