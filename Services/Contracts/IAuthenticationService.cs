
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistirationDto userForRegistirationDto);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuthDto);
    Task<String> CreateToken();



}
