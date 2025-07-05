using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services;

public class AuthenticationManager : IAuthenticationService
{
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private User? _user; 

    public AuthenticationManager(ILoggerService logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateToken()
    {
        var signinCredentials = GetSignningCredentials();
        var claims = await GetClaims();
        var tokenOptions=GenerateTokenOptions(signinCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signinCredentials);

        return tokenOptions;
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,_user.UserName),
        };

        var roles = await _userManager.GetRolesAsync(_user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));
        }

        return claims;

    }

    private SigningCredentials GetSignningCredentials()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
        var secret= new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistirationDto userForRegistirationDto)
    {
        var user = _mapper.Map<User>(userForRegistirationDto);  

        var result = await _userManager.CreateAsync(user,userForRegistirationDto.Password); // Password is a property of UserForRegistirationDto

        if(result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, userForRegistirationDto.Roles); // Roles is a property of UserForRegistirationDto
        }
        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthDto)
    {
        _user = await _userManager.FindByNameAsync(userForAuthDto.UserName);
        var result= (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthDto.Password));
        if (!result)
            _logger.LogWarning($"{nameof(ValidateUser)} : Authentication failed. Wrong username or Password");

        return result;
    }
}
