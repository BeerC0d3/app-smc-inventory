using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.Seccion;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.Comite.Periodos;
using BeerC0d3.API.Services.Comite.Personas;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class PersonasController : BaseApiController
    {
        private readonly IPersonaService _personaService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonasController(IPersonaService personaService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personaService = personaService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("AddUpdatePersona")]
        public async Task<ActionResult> AddUpdatePersona(PersonaAddUpdateDto model)
        {

            var result = await _personaService.AddUpdate(model);
            return Ok(result);
        }

        [HttpGet("GetPersona/{personaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> GetPersona(int personaId)
        {

            var result = await _unitOfWork.Persona.GetByIdAsync(personaId);
            return _mapper.Map<PersonaDto>(result);
        }

        [HttpGet("GetPersonasBySeccionUser/{seccionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PersonaDto>>> GetPersonasBySeccionUser(int seccionId)
        {

            int userId = new UserClaim(HttpContext).UserID;
            var dapperParams = new
            {
                seccionId = seccionId,
                userId = userId
            };

            var result = await _unitOfWork.ExecProcedureToList("Comite.sp_GetPersonaBySeccionUser", dapperParams);
            return _mapper.Map<List<PersonaDto>>(result);
        }

        [HttpGet("GetPersonasCooperacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PersonaCooperacionDto>>> GetPersonasCooperacion(int seccionId,string nombre)
        {

            int userId = new UserClaim(HttpContext).UserID;
            int periodoId = new UserClaim(HttpContext).PoID;
            var dapperParams = new
            {
                seccionId = seccionId,
                periodoId = periodoId,
                userId = userId,
              
                nombre = nombre == null ? string.Empty : nombre,
            };

            var result = await _unitOfWork.ExecProcedureToList("Comite.sp_GetPersonaCooperacionByUser", dapperParams);
            return _mapper.Map<List<PersonaCooperacionDto>>(result);
        }


        [HttpPost("CooperacionPersona")]
        public async Task<ActionResult> CooperacionPersona(CooperacionPersonaDto model)
        {
            int periodoId = new UserClaim(HttpContext).PoID;
            model.periodoId = periodoId;
            var result = await _personaService.CooperacionPersona(model);
            return Ok(result);
        }

        [HttpGet("GetTotalCooperacionByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TotalCooperacionDto>> GetTotalCooperacionByUser()
        {

            int userId = new UserClaim(HttpContext).UserID;
            int periodoId = new UserClaim(HttpContext).PoID;
            var dapperParams = new
            {
                tipoMonto = "Usuario",
                periodoId = periodoId,
                usuarioId = userId,

            };

            var result = await _unitOfWork.ExecProcedure("Comite.sp_GetTotalCooperacion", dapperParams);
            return _mapper.Map<TotalCooperacionDto>(result);
        }

    }
}
