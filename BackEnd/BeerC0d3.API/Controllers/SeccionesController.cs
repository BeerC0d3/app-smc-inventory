using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Comite.Seccion;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Helpers.Errors;
using BeerC0d3.API.Services.Comite.Periodos;
using BeerC0d3.API.Services.Comite.Secciones;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class SeccionesController : BaseApiController
    {
        private readonly ISeccionService _seccionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeccionesController(ISeccionService seccionService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _seccionService = seccionService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("AddUpdatePeriodo")]
        public async Task<ActionResult> AddUpdatePeriodo(SeccionAddUpdateDto model)
        {
            int  user = new UserClaim(HttpContext).UserID;
          
            var result = await _seccionService.AddUpdate(model, user);
            return Ok(result);
        }

        [HttpGet("GetSecciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SeccionDto>>> GetSecciones()
        {

            int userId = new UserClaim(HttpContext).UserID;
            var dapperParams = new
            {
                userId = userId
            };
            //var result = await _unitOfWork.Secciones.GetActiveAllByUserAsync(userId);
            var result = await _unitOfWork.ExecProcedureToList("Comite.sp_GetSeccionByUser", dapperParams);
            return _mapper.Map<List<SeccionDto>>(result);
        }

        [HttpGet("GetSeccionesByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SeccionDto>>> GetSeccionesByUser()
        {

            int userId = new UserClaim(HttpContext).UserID;
            var dapperParams = new
            {
                userId = userId
            };

            var result = await _unitOfWork.ExecProcedureToList("Comite.sp_GetSeccionByUser", dapperParams);
            return _mapper.Map<List<SeccionDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SeccionDto>> Get(int id)
        {
            var seccion = await _unitOfWork.Secciones.GetByIdAsync(id);
            if (seccion == null)
                return NotFound(new ApiResponse(404, "La sección solicitada no existe."));

            return _mapper.Map<SeccionDto>(seccion);
        }
        //DELETE: api/Seccion
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var seccion = await _unitOfWork.Secciones.GetByIdAsync(id);
            if (seccion == null)
                return NotFound();

            _unitOfWork.Secciones.Remove(seccion);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
