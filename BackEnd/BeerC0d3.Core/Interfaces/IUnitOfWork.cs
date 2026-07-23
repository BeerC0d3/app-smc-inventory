using BeerC0d3.Core.Entities.Sistema;
using BeerC0d3.Core.Interfaces.Comite;
using BeerC0d3.Core.Interfaces.Seguridad;
using BeerC0d3.Core.Interfaces.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRolRepository Roles { get; }
        IUsuarioRepository Usuarios { get; }
        IMenuRepository Menus { get; }
        ICatalogoDetalleRepository catalogoDetalle { get; }
        ICatalogoRepository Catalogo { get; }
        IPeriodoRepository Periodos { get; }
        IIngresosRepository Ingresos { get; }
        IEgresosRepository Egresos { get; }
        ISeccionRepository Secciones { get; }
        IPersonaRepository Persona { get; }
        ICooperacionRepository Cooperacion { get; }
        IBoletoAutobusRepository BoletoAutobus { get; }
        IVentaBoletoAutobusRepository VentaBoletoAutobus { get; }
        IVentaMontoBoletoAutobusRepository  VentaMontoBoletoAutobus { get; }
        IVentaDetalleBoletoAutobusRepository VentaDetalleBoletoAutobus { get; }
    

        Task<IEnumerable<dynamic>> ExecProcedureToList(string nameprocedure, object parameters = null);
        Task<dynamic> ExecProcedure(string nameprocedure, object parameters = null);
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task<int> SaveAsync();
    }
}
