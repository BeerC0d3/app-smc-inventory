using BeerC0d3.Core.Interfaces;
using BeerC0d3.Core.Interfaces.Comite;
using BeerC0d3.Core.Interfaces.Seguridad;
using BeerC0d3.Core.Interfaces.Sistema;
using BeerC0d3.Infrastructure.Data;
using BeerC0d3.Infrastructure.Repositories.Comite;
using BeerC0d3.Infrastructure.Repositories.Seguridad;
using BeerC0d3.Infrastructure.Repositories.Sistema;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BeerCodeContext _context;
        private IDbContextTransaction _transaction;
        private ICatalogoRepository _catalogo;
        private ICatalogoDetalleRepository _catalogoDetalle;
        private IUsuarioRepository _usuarios;
        private IMenuRepository _menus;
        private IRolRepository _roles;
        private IPeriodoRepository _periodos;
        private IIngresosRepository _ingresos;
        private IEgresosRepository _egresos;
        private ISeccionRepository _secciones;
        private IPersonaRepository _persona;
        private ICooperacionRepository _cooperaciones;
        private IBoletoAutobusRepository _boletoAutobus;
        private IVentaBoletoAutobusRepository _ventaBoletoAutobus;
        private IVentaMontoBoletoAutobusRepository _ventaMontoBoletoAutobus;
        private IVentaDetalleBoletoAutobusRepository _ventaDetalleBoletoAutobus;

        public UnitOfWork(BeerCodeContext context)
        {
            _context = context;
        }
        public ICatalogoRepository Catalogo
        {
            get
            {
                if (_catalogo == null)
                {
                    _catalogo = new CatalogoRepository(_context);
                }
                return _catalogo;
            }
        }
        public ICatalogoDetalleRepository catalogoDetalle
        {
            get
            {
                if (_catalogoDetalle == null)
                {
                    _catalogoDetalle = new CatalogoDetalleRepository(_context);
                }
                return _catalogoDetalle;
            }
        }
        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new UsuarioRepository(_context);
                }
                return _usuarios;
            }
        }

        public IMenuRepository Menus
        {
            get
            {
                if (_menus == null)
                {
                    _menus = new MenuRepository(_context);
                }

                return _menus;
            }
        }
        public IRolRepository Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public IPeriodoRepository Periodos
        {
            get
            {
                if (_periodos == null)
                {
                    _periodos = new PeriodoRepository(_context);
                }
                return _periodos;
            }
        }

        public IIngresosRepository Ingresos
        {
            get
            {
                if (_ingresos == null)
                {
                    _ingresos = new IngresosRepository(_context);
                }
                return _ingresos;
            }
        }

        public IEgresosRepository Egresos
        {
            get
            {
                if (_egresos == null)
                {
                    _egresos = new EgresosRepository(_context);
                }
                return _egresos;
            }
        }

        public ISeccionRepository Secciones
        {
            get
            {
                if (_secciones == null)
                {
                    _secciones = new SeccionRepository(_context);
                }
                return _secciones;
            }
        }

        public IPersonaRepository Persona
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new PersonaRepository(_context);
                }

                return _persona;
            }
        }

        public ICooperacionRepository Cooperacion
        {
            get
            {
                if (_cooperaciones == null)
                {
                    _cooperaciones = new CooperacionRepository(_context);
                }

                return _cooperaciones;
            }
        }

        public IBoletoAutobusRepository BoletoAutobus
        {
            get
            {
                if (_boletoAutobus == null)
                {
                    _boletoAutobus = new BoletoAutobusRepository(_context);
                }

                return _boletoAutobus;
            }
        }

        public IVentaBoletoAutobusRepository VentaBoletoAutobus
        {
            get
            {
                if (_ventaBoletoAutobus == null)
                {
                    _ventaBoletoAutobus = new VentaBoletoRepository(_context);
                }

                return _ventaBoletoAutobus;
            }
        }

        public IVentaMontoBoletoAutobusRepository VentaMontoBoletoAutobus
        {
            get
            {
                if (_ventaMontoBoletoAutobus == null)
                {
                    _ventaMontoBoletoAutobus = new VentaMontoBoletoAutobusRepository(_context);
                }
                return _ventaMontoBoletoAutobus;
            }
        }
        public IVentaDetalleBoletoAutobusRepository VentaDetalleBoletoAutobus
        {
            get
            {
                if (_ventaDetalleBoletoAutobus == null)
                {
                    _ventaDetalleBoletoAutobus = new VentaDetalleBoletoAutobusRepository(_context);
                }

                return _ventaDetalleBoletoAutobus;
            }
        }

    
        public async Task<IEnumerable<dynamic>> ExecProcedureToList(string nameprocedure, object parameters = null)
        {
            var con = _context.Database.GetDbConnection();
            IDbTransaction tran = null;
            if (_transaction != null)
                tran = _transaction.GetDbTransaction();

            if (con.State != ConnectionState.Open)
                con.Open();

            var reader = await con.QueryAsync(nameprocedure, parameters, commandType: CommandType.StoredProcedure, transaction: tran);
            var resultList = reader.ToList();


            return resultList;

        }
        public async Task<dynamic> ExecProcedure(string nameprocedure, object parameters = null)
        {
            var con = _context.Database.GetDbConnection();
            IDbTransaction tran = null;
            if (_transaction != null)
                tran = _transaction.GetDbTransaction();

            if (con.State != ConnectionState.Open)
                con.Open();

            var reader = await con.QueryAsync(nameprocedure, parameters, commandType: CommandType.StoredProcedure, transaction: tran);
            // var resultList = reader.ToList();


            return reader.FirstOrDefault();

        }

        public async void CreateTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async void Commit()
        {
            await _transaction.CommitAsync();
        }
        public async void Rollback()
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
