using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IValidatorService _validatorService;
        public AuthController(IUsersService userService, IValidatorService validatorService)
        {
            _userService = userService;
            _validatorService = validatorService;
        }

        [HttpPost("register")]//Post api/auth/register
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            // check for invalid registerRequest
            if (userRegisterRequest == null)
            {
                return BadRequest("invalid registration data");
            }
            ValidationResult validationResult =  _validatorService.Validate(userRegisterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            // Call the usersServic to handle register
            AuthenticationResponse? authenticationResponse = await _userService.Register(userRegisterRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

        //Endpoint for user login user case
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {

            ValidationResult validationResult = _validatorService.Validate(userLoginRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            // check for invalid login request
            if (userLoginRequest == null)
            {
                return BadRequest("Invalid login data");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(userLoginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);


        }
    }
}
