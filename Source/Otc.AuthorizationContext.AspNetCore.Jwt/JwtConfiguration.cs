using Otc.ComponentModel.DataAnnotations;
using System;

namespace Otc.SessionContext.AspNetCore.Jwt
{
    [Obsolete("Otc.SessionContext.AspNetCore.Jwt.JwtConfiguration now is Otc.AuthorizationContext.AspNetCore.Jwt.JwtConfiguration. We strongly encourage you to migrate from Otc.SessionContext.AspNetCore.Jwt to Otc.AuthorizationContext.AspNetCore.Jwt.")]
    public class JwtConfiguration
    {
        [Required]
        public string Issuer { get; set; }
        [Required]
        public string SecretKey { get; set; }
        [Required]
        public string Audience { get; set; }

        public int ExpiresMinutes { get; set; } = 60;

        internal const string SessionDataJwtTypeName = "otc-session-data";
    }
}

namespace Otc.AuthorizationContext.AspNetCore.Jwt
{
    public class JwtConfiguration
    {
        [Required]
        public string Issuer { get; set; }
        [Required]
        public string SecretKey { get; set; }
        [Required]
        public string Audience { get; set; }

        public int ExpiresMinutes { get; set; } = 60;

        internal const string AuthorizationDataJwtTypeName = "otc-authorization-data";
    }
}
