using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public sealed class AuthenticationController:ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public AuthenticationController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
    }
    [HttpPost("register")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistirationDto userForRegistirationDto)
    {
    
        var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegistirationDto);
        
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
           
             
        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> LoginUser([FromBody] UserForAuthenticationDto userForAuthDto)
    {
       if(!await _serviceManager.AuthenticationService.ValidateUser(userForAuthDto))
       {
          return Unauthorized(new { message = "Invalid credentials" });
       }
       return Ok(new
       {
           Token = await _serviceManager.AuthenticationService.CreateToken()
       });
    }
}
