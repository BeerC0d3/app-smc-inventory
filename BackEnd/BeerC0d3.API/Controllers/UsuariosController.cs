using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Seguridad;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.Seguridad;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerC0d3.API.Controllers
{
  
    public class UsuariosController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuariosController(IUserService userService,IUnitOfWork unitOfWork,IMapper mapper)
        {

            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(UserRegisterDto model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(LoginDto model)
        {
            var result = await _userService.GetTokenAsync(model);
            if (!result.EstaAutenticado)
                return BadRequest(new { message = result.Mensaje });

            SetRefreshTokenInCookie(result.RefreshToken);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuarios()
        {


            var result = await _userService.GetUsuariosActive();
            return _mapper.Map<List<UsuarioDto>>(result);
        }

        [Authorize]
        [HttpGet("GetRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<RolDto>>> GetRoles()
        {


            var result = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<List<RolDto>>(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            if (refreshToken != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(10),
                };
                Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
            }
        }
    }
}
