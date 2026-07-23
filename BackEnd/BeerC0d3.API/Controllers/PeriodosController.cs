using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Seguridad;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.Comite.Periodos;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class PeriodosController : BaseApiController
    {
        private readonly IPeriodoService _periodoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PeriodosController(IPeriodoService periodoService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _periodoService = periodoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("AddUpdatePeriodo")]
        public async Task<ActionResult> AddUpdatePeriodo(PeriodoAddUpdateDto model)
        {
            var user = new UserClaim(HttpContext).UserID;
            model.UsuarioModificacion = user.ToString();
            var result = await _periodoService.AddUpdatePeriodo(model);
            return Ok(result);
        }
        [HttpGet("GetPeriodos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PeriodosDto>>> GetTags()
        {
            //var dapperParams = new
            //{
            //    tipoMovimientoID = "",
            //    movimientoID = 17
            //};
            var poId = new UserClaim(HttpContext).PoID;

            var result = await _unitOfWork.ExecProcedureToList("Comite.sp_GetPeriodos");


            return _mapper.Map<List<PeriodosDto>>(result);
        }
    }
}
