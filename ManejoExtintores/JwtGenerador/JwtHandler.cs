using ManejoExtintores.Core.Modelos;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Google.Apis.Auth;
using ManejoExtintores.Core.DTOs.Request;

namespace ManejoExtintores.JwtGenerador
{
    public class JwtHandler
    {
		private readonly IConfiguration _configuracion; 
		private readonly IConfigurationSection _jwtConfiguracion; 
		private readonly IConfigurationSection _goolgeSettings;
		private readonly UserManager<Usuarios> _userManager;
		public JwtHandler(IConfiguration configuracion, UserManager<Usuarios> userManager)
		{
			_userManager = userManager;
			_configuracion = configuracion;
			_jwtConfiguracion = _configuracion.GetSection("JWTConfiguracion");
			_goolgeSettings = _configuracion.GetSection("GoogleAuthSettings");
		}

		private SigningCredentials ObtenerFirmaCredenciales() 
		{
			var key = Encoding.UTF8.GetBytes(_jwtConfiguracion.GetSection("securityKey").Value);
			var secret = new SymmetricSecurityKey(key);

			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		private async Task<List<Claim>> ObtenerClaims(Usuarios usuario) 
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, usuario.Email)
			};

			var roles = await _userManager.GetRolesAsync(usuario);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			return claims;
		}
		 
		private JwtSecurityToken GenerarTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				issuer: _jwtConfiguracion.GetSection("validIssuer").Value,
				audience: _jwtConfiguracion.GetSection("validAudience").Value,
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguracion.GetSection("expiryInMinutes").Value)),
				signingCredentials: signingCredentials);

			return tokenOptions;
		}

		public async Task<string> GenerarToken(Usuarios user) 
		{
			var firmacredenciales = ObtenerFirmaCredenciales();
			var claims = await ObtenerClaims(user);
			var opcionestoken = GenerarTokenOptions(firmacredenciales, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(opcionestoken);

			return token;
		}

		public async Task<GoogleJsonWebSignature.Payload> VerificacionGoogleToken(AutenticacionExternaDTO autentificacionExt) 
		{
			try 
			{
				var configuracion = new GoogleJsonWebSignature.ValidationSettings()
				{
					Audience = new List<string>() { _goolgeSettings.GetSection("clientId").Value }
				};

				var payload = await GoogleJsonWebSignature.ValidateAsync(autentificacionExt.IdToken, configuracion);
				return payload;
			}
			catch (Exception ex)
			{
				//log an exception
				return null;
			}
		}
	}
}
