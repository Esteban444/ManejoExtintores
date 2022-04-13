using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace HandlingExtinguishers.WebApi.Controllers
{
	[Route("api/accounts")]
	[ApiController]
	[AllowAnonymous]
	
	public class AccountsController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AccountsController(IAuthService service)
		{
			_authService = service;
		}

		[HttpPost("register-in")]
		public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDto registerUser)
		{
			var result = await _authService.RegisterUser(registerUser);
			return Ok(result);
		}

		[HttpPost("Login-in")]
		public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequest)
		{
           var result = await _authService.LoginUser(loginRequest);
		   return Ok(result);
		}

	}
}
