using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace HandlingExtinguishers.Core.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ISettingsRepository _settingsRepository;
        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper,
            ISettingsRepository settingsRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _settingsRepository = settingsRepository;
        }

        public async Task<AuthenticationResponseDto> LoginUser(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null) throw new GlobalException("The user does not exist.", HttpStatusCode.BadRequest);

            if (!await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var password = await _userManager.AccessFailedAsync(user);
                if (password == null) throw new GlobalException("Pasword invalid.", HttpStatusCode.Unauthorized);
            }

            var result = await GenerateToken(loginRequest);

            return result;
        }

        public async Task<RegisterResponseDto> RegisterUser(RegisterUserRequestDto registerUser)
        {
            //if (registerUser == null || !ModelState.IsValid)
                //return BadRequest();
            var user = _mapper.Map<ApplicationUser>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded) throw new GlobalException("The user already exists.", HttpStatusCode.BadRequest);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", user.Email }
            };

            await _userManager.AddToRoleAsync(user, "Admin");
            var newUser = await _userManager.FindByEmailAsync(registerUser.Email);
            var response = new RegisterResponseDto()
            {
                Id = Guid.Parse(newUser.Id),
                Email = user.Email,
                UserName = newUser.UserName
            };
            return response;
        }

        private async Task<AuthenticationResponseDto> GenerateToken(LoginRequestDto authentication)
        {
            var identityUser = await _userManager.FindByEmailAsync(authentication.Email);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, authentication.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            claims.Add(new Claim(ClaimTypes.NameIdentifier, identityUser.Id));

            var claimsDB = await _userManager.GetClaimsAsync(identityUser);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsRepository["JWTKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(15);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _settingsRepository["issuer"],
                audience: _settingsRepository["audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            var user = await _userManager.FindByEmailAsync(authentication.Email);

            var auth = new AuthenticationResponseDto()
            {
                Id = Guid.Parse(user.Id),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = identityUser.Email,
                Expiration = expiration,
            };
            return auth;
        }
    }
}
