using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Insight.Authentication.Schemes
{
    public class JwtAuthenticationScheme : IAuthenticationScheme
    {
        public void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "",
                        ValidAudience = "",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""))
                    };
                });
        }

        /// <summary>
        /// Note: In future work I will most likely gate the logic for creating tokens to my web service
        /// behind private methods and an internal class, and take away this logic from the IAuthenticationScheme type
        /// </summary>
        /// <returns></returns>
        public string CreateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
