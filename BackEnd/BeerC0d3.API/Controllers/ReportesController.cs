using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.Reportes;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.Comite.ReportesPdf;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class ReportesController : BaseApiController
    {
        private readonly IGeneratePdfService _serviceReport;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportesController(IGeneratePdfService serviceReport, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _serviceReport = serviceReport;
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        [HttpGet("ReporteCooperacionIntegrante")]
        public async Task<ActionResult> ReporteCooperacionIntegrante()
        {
            int userId = new UserClaim(HttpContext).UserID;
            int periodoId = new UserClaim(HttpContext).PoID;

            var dapperParams = new
            {
                periodoId = periodoId,
                usuarioId = userId,

            };


            var resultTotal = await _unitOfWork.ExecProcedure("Comite.sp_Rpt_TotalCooperacion", dapperParams);
            RptTotalCooperacionDto resultMapper = _mapper.Map<RptTotalCooperacionDto>(resultTotal);

            var resultDetalle = await _unitOfWork.ExecProcedureToList("Comite.sp_Rpt_CooperacionDetalle", dapperParams);
            ICollection<PersonaCooperacionDto> resultDetalleMapper = _mapper.Map<ICollection<PersonaCooperacionDto>>(resultDetalle);


            byte[] data =  _serviceReport.ReporteCooperacionIntegrante(resultMapper, resultDetalleMapper)
                           .GeneratePdf();
            string contentType = "application/pdf";
            HttpContext.Response.ContentType = contentType;
            var result = new FileContentResult(data, contentType)
            {
                FileDownloadName = "mipdf.pdf"
            };

            return result;

        }
    }
}
