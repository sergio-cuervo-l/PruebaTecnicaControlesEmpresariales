using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.DTOs;
using PruebaTecnica.Application.Interfaces;

namespace PruebaTecnica.API.Controllers
{
    /// <summary>
    /// Defines API endpoints for user authentication operations, including user registration and login.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the AuthController class using the specified authentication service.
        /// </summary>
        /// <param name="authService">The authentication service to be used by the controller. Cannot be null.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Crear un nuevo usuario para inicio de sesion.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var result = await _authService.RegisterAsync(request);

            if (!result)
            {
                return BadRequest(new
                {
                    Message = "El usuario ya existe"
                });
            }

            return Ok(new
            {
                Message = "El usuario se agrego correctamente"
            });
        }

        /// <summary>
        /// Autenticatión de un usuario existente y generación de un token JWT para acceso a los endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var token = await _authService.LoginAsync(request);

            if (token == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid credentials"
                });
            }

            return Ok(new
            {
                Token = token
            });
        }
    }
}
