using Otc.ComponentModel.DataAnnotations;

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
