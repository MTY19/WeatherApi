using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WeatherApp.Application.Interfaces.Token;

namespace WeatherApi.Infrastructure.Services.Token
{
	public class TokenHandler:ITokenHandler
	{
        IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public WeatherApp.Application.Dto.Token CreateAccessToken()
        {
            WeatherApp.Application.Dto.Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(Double.Parse(configuration["TokenOptions:AccessTokenExpiration"]));

            JwtSecurityToken securityToken = new(
                  audience: configuration["TokenOptions:Audience"],
                  issuer: configuration["TokenOptions:Issuer"],
                  expires: token.Expiration,
                  notBefore: DateTime.UtcNow,
                  signingCredentials: signingCredentials
                ); 

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;           
        }
    }
}

