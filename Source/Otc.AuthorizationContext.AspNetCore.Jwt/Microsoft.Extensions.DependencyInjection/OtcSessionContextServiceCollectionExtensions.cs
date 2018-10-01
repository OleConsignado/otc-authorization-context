using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Otc.AuthorizationContext.Abstractions;
using Otc.AuthorizationContext.AspNetCore.Jwt;
using Otc.SessionContext.Abstractions;
using Otc.SessionContext.AspNetCore.Jwt;
using System;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OtcSessionContextServiceCollectionExtensions
    {
        [Obsolete("Use AddOtcAspNetCoreJwtAuthorizationContext instead; Otc.SessionContext.AspNetCore.Jwt now is Otc.AuthorizationContext.AspNetCore.Jwt. We strongly encourage you to migrate from Otc.SessionContext.AspNetCore.Jwt to Otc.AuthorizationContext.AspNetCore.Jwt.")]
        public static IServiceCollection AddOtcAspNetCoreJwtSessionContext(this IServiceCollection services, Otc.SessionContext.AspNetCore.Jwt.JwtConfiguration jwtConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (jwtConfiguration == null)
            {
                throw new ArgumentNullException(nameof(jwtConfiguration));
            }

            services.AddSingleton(jwtConfiguration);
            services.AddSingleton(typeof(ISessionSerializer<>), typeof(SessionSerializer<>));
            services.AddScoped(typeof(ISessionContext<>), typeof(SessionContext<>));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var apiConfiguration = jwtConfiguration;

                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = apiConfiguration.Issuer,
                        ValidAudience = apiConfiguration.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(apiConfiguration.SecretKey))
                    };
                });

            return services;
        }

        public static IServiceCollection AddOtcAspNetCoreJwtAuthorizationContext(this IServiceCollection services, Otc.AuthorizationContext.AspNetCore.Jwt.JwtConfiguration jwtConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (jwtConfiguration == null)
            {
                throw new ArgumentNullException(nameof(jwtConfiguration));
            }

            services.AddSingleton(jwtConfiguration);
            services.AddSingleton(typeof(IAuthorizationDataSerializer<>), typeof(AuthorizationDataSerializer<>));
            services.AddScoped(typeof(IAuthorizationContext<>), typeof(AuthorizationContext<>));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var apiConfiguration = jwtConfiguration;

                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = apiConfiguration.Issuer,
                        ValidAudience = apiConfiguration.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(apiConfiguration.SecretKey))
                    };
                });

            return services;
        }
    }
}
