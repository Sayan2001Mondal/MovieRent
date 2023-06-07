using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRent.Web.DTOs;
using MovieRent.Web.Infrastructure;
using MovieRent.Web.Models;
using MovieRent.Web.Services;

namespace MovieRent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }
            /// <summary>
            /// Method For Register
            /// </summary>

            [HttpPost("Register")]
            public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterDTO request)
            {
                var response = await _authService.Register
                    (
                        new User
                        {
                            Name = request.Name,
                            Email = request.Email
                            //Role="Company"
                        },
                        request.Password
                    );
                if (!response.Success)
                {
                new Error("Login not Successfull for Email : " + request.Email);
                //new Error(response.Message);
                return BadRequest(response);
                }
                return Ok(response);
            }
            /// <summary>
            /// Method To Login into System.Provides JWT token
            /// </summary>

            [HttpPost("Login")]
            public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDTO request)
            {
                var response = await _authService.Login(request.Email, request.Password);
                if (!response.Success)
                {
                new Error("Login not Successfull for Email : " + request.Email);
                    return BadRequest(response);
                }
                return Ok(response);
            }
        }
}
