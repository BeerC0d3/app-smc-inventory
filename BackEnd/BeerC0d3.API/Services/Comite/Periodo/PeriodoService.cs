using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Interfaces;
using BeerC0d3.Infrastructure.UnitOfWork;

namespace BeerC0d3.API.Services.Comite.Periodos
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<string> AddUpdatePeriodo(PeriodoAddUpdateDto periodoDto)
        {
            //Periodo periodo = null;
            try
            {
                _unitOfWork.CreateTransaction();

                var catDetalle = await _unitOfWork.catalogoDetalle.GetCatDetalleByClaveAsync("MONTO_INICIO_PERIODO");
                
                var periodo = await _unitOfWork.Periodos.GetByPeoIdAsync(periodoDto.Id);
               

                var ingresos = _unitOfWork.Ingresos.Find(item => item.PeriodoId == periodoDto.Id && item.ConcentoId == catDetalle.Id)
                            .FirstOrDefault();

                if (periodo == null)
                {
                    periodo = new Periodo();
                    periodo.FechaAlta = DateTime.Now;
                    periodo.Activo = true;
                }

                periodo.Nombre = periodoDto.Nombre;
                periodo.EstatusId = periodoDto.EstatusId;
                periodo.UsuarioAlta = periodoDto.UsuarioModificacion;

              
                if (periodo.Id == 0)
                    _unitOfWork.Periodos.Add(periodo);
                else
                    _unitOfWork.Periodos.Update(periodo);

                await _unitOfWork.SaveAsync();

                //Eliminamos todos los usuarios a este periodo
                if (periodo.UsuarioPeriodos != null){
                    foreach (var item in periodo.UsuarioPeriodos)
                        periodo.UsuarioPeriodos.Remove(item);
                }


                
                //iteramos todos los usuarios seleccionados
                string[] users = periodoDto.IntegrantesId.Split(',');
                foreach (string userId in users)
                {
                    
                    if(periodo.UsuarioPeriodos == null)
                        periodo.UsuarioPeriodos = new List<UsuarioPeriodo>();

                    var userPeriodo = new UsuarioPeriodo();
                    userPeriodo.PeriodoId = periodo.Id;
                    userPeriodo.UsuarioId = int.Parse(userId);
                    userPeriodo.FechaAlta = DateTime.Now;
                    periodo.UsuarioPeriodos.Add(userPeriodo);
                    //periodoUsers.UsuarioPeriodos.Add(userPeriodo);
                }

               

                // agregamos o actualizamos los ingresos
                if (ingresos == null)
                {
                    ingresos = new Ingresos();
                    ingresos.FechaAlta = DateTime.Now;
                }

                ingresos.PeriodoId = periodo.Id;
                ingresos.ConcentoId = catDetalle.Id;
                ingresos.Monto = periodoDto.Monto;
                ingresos.Descripcion = null;
                ingresos.FechaModificacion = DateTime.Now;
                ingresos.UsuarioModificacion = periodoDto.UsuarioModificacion;

                if (ingresos.Id == 0)
                    _unitOfWork.Ingresos.Add(ingresos);
                else
                    _unitOfWork.Ingresos.Update(ingresos);

                await _unitOfWork.SaveAsync();


                _unitOfWork.Commit();

                return $"El periodo  {periodoDto.Nombre} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                var message = ex.Message;
                throw new Exception($"Error: {message}");
                //return $"Error: {message}";
            }
        }

        public Task<string> AddWithUsersPeriodo()
        {
            throw new NotImplementedException();
        }
    }
}
