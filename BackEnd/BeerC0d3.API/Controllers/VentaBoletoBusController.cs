using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.VentaBoletoBus;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.Comite.Personas;
using BeerC0d3.API.Services.Comite.VentaBoletoBus;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class VentaBoletoBusController :BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVentaBoletoBusService _ventaBoletoBusService;
        private readonly IMapper _mapper;
        public VentaBoletoBusController(IUnitOfWork unitOfWork, IVentaBoletoBusService ventaBoletoBusService, IMapper mapper)
        {
           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ventaBoletoBusService = ventaBoletoBusService;
        }

        [HttpGet("GetBoletoAutobus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BoletoAutobusDto>>> GetBoletos()
        {

            var result = await _unitOfWork.BoletoAutobus.GetAllActive();
            return _mapper.Map<List<BoletoAutobusDto>>(result);
        }

        [HttpGet("GetAllBoletoPersonaByUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<VentaBoletoPersonaAutobusDto>>> GetAllBoletoPersonaByUsuario(int estatusId,string nombrePersona)
        {


            int userId = new UserClaim(HttpContext).UserID;
            int periodoId = new UserClaim(HttpContext).PoID;
            var dapperParams = new
            {
             
                periodoId = periodoId,
                estatusId = estatusId,
                usuarioId = userId,
                nombrePersona = nombrePersona == null ? string.Empty : nombrePersona,
            };

            var result = await _unitOfWork.ExecProcedureToList("Comite.sp_GetAllBoletoPersonaByUsuario", dapperParams);
            return _mapper.Map<List<VentaBoletoPersonaAutobusDto>>(result);
        }

        [HttpGet("GetResumenVentaBoletoAutobusByUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VentaBoletoAutobusResumenDto>> GetResumenVentaBoletoAutobusByUsuario()
        {


            int userId = new UserClaim(HttpContext).UserID;
            int periodoId = new UserClaim(HttpContext).PoID;
            var dapperParams = new
            {

                periodoId = periodoId,
                usuarioId = userId,
                
            };

            var result = await _unitOfWork.ExecProcedure("Comite.sp_GetResumenVentaBoletoAutobusByUsuario", dapperParams);
            return _mapper.Map<VentaBoletoAutobusResumenDto>(result);
        }

        [HttpPost("AddUpdateVentaBoletoBus")]
        public async Task<ActionResult> AddUpdateVentaBoletoBus(VentaBoletoAutobusAddUpdateDto model)
        {

            var result = await _ventaBoletoBusService.AddUpdateVentaBoleto(model);
            return Ok(result);
        }
    }
}
