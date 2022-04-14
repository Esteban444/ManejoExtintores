using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/accounts")]
	[ApiController]
	[AllowAnonymous]
	public class AccountsController : ControllerBase
	{
		private readonly IAuthService _authService;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="service"></param>
		public AccountsController(IAuthService service)
		{
			_authService = service;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="registerUser"></param>
		/// <returns></returns>
		[HttpPost("register-in")]
		public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDto registerUser)
		{
			var result = await _authService.RegisterUser(registerUser);
			return Ok(result);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="loginRequest"></param>
		/// <returns></returns>
		[HttpPost("Login-in")]
		public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequest)
		{
           var result = await _authService.LoginUser(loginRequest);
		   return Ok(result);
		}

	}
}
