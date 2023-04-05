using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AutheticationController : ControllerBase
    {

        private readonly IAuthenticationServices _autheticationServices;

        public AutheticationController(IAuthenticationServices autheticationServices)
        {
            _autheticationServices = autheticationServices;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _autheticationServices.Register(
                request.firstname,
                request.lastname,
                request.email,
                request.password);

            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _autheticationServices.Login(
                request.email,
                request.password);

            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }

    }
}