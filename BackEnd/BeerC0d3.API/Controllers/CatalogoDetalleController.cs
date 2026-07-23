using AutoMapper;
using BeerC0d3.API.Dtos.Sistema;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class CatalogoDetalleController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CatalogoDetalleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetCatalogo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<CatalogoDto>>> GetCatalogo()
        {

            var result = await _unitOfWork.Catalogo.GetAllAsync();
            return _mapper.Map<List<CatalogoDto>>(result);
        }

        [HttpGet("GetByCatalogo/{claveCatalogo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ResultCatDetalleDto>>> GetByCatalogo(string claveCatalogo)
        {

            var result = await _unitOfWork.catalogoDetalle.GetCatDetalleByCatClaveAsync(claveCatalogo.Trim());
            return _mapper.Map<List<ResultCatDetalleDto>>(result);
        }
    }
}
