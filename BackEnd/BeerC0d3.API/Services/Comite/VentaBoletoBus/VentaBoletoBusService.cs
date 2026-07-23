using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Comite.VentaBoletoBus;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces;
using BeerC0d3.Infrastructure.UnitOfWork;

namespace BeerC0d3.API.Services.Comite.VentaBoletoBus
{
    public class VentaBoletoBusService : IVentaBoletoBusService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VentaBoletoBusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddUpdateVentaBoleto(VentaBoletoAutobusAddUpdateDto model)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                var ventaBoleto = _unitOfWork.VentaBoletoAutobus
                                    .Find(item => item.Id == model.VentaBoleto.Id)
                                    .FirstOrDefault();

                //venta de boletos
                if (ventaBoleto == null)
                {
                    ventaBoleto = new VentaBoletoAutobus();
                    ventaBoleto.FechaAlta = DateTime.Now;
                    ventaBoleto.Activo = true;

                }

                ventaBoleto.PersonaId = model.VentaBoleto.PersonaId;
                ventaBoleto.PeriodoId = model.VentaBoleto.PeriodoId;
                ventaBoleto.EstatusId = model.VentaBoleto.EstatusId;

                if (ventaBoleto.Id == 0)
                    _unitOfWork.VentaBoletoAutobus.Add(ventaBoleto);
                else
                    _unitOfWork.VentaBoletoAutobus.Update(ventaBoleto);

                await _unitOfWork.SaveAsync();

                //Monto Venta Boleto
                var montoVenta = await _unitOfWork.VentaMontoBoletoAutobus.GetByIdAndVentaBoletoIdActive(model.VentaMontoBoleto.Id, ventaBoleto.Id);
                if (montoVenta == null)
                {
                    montoVenta = new VentaMontoBoletoAutobus();
                    montoVenta.FechaAlta = DateTime.Now;
                    montoVenta.Activo = true;
                }

                montoVenta.Monto = model.VentaMontoBoleto.Monto;
                montoVenta.VentaBoletoAutId = ventaBoleto.Id;

                if (montoVenta.Id == 0)
                    _unitOfWork.VentaMontoBoletoAutobus.Add(montoVenta);
                else
                    _unitOfWork.VentaMontoBoletoAutobus.Update(montoVenta);

                await _unitOfWork.SaveAsync();

                foreach (var item in model.VentaDetalleBoleto)
                {
                    var detalleBoleto = await _unitOfWork.VentaDetalleBoletoAutobus.GetByIdAndVentaBoletoId(item.Id, ventaBoleto.Id);

                    if(detalleBoleto == null)
                    {
                        detalleBoleto = new VentaDetalleBoletoAutobus();
                        detalleBoleto.FechaAlta = DateTime.Now;
                        detalleBoleto.Activo = true;
                    }

                    detalleBoleto.BoletoAutId = item.BoletoId;
                    detalleBoleto.VentaBoletoAutId = ventaBoleto.Id;
                    detalleBoleto.Cantidad = item.Cantidad;
                    detalleBoleto.Precio = item.Precio;

                    if(detalleBoleto.Id == 0)
                        _unitOfWork.VentaDetalleBoletoAutobus.Add(detalleBoleto);
                    else
                        _unitOfWork.VentaDetalleBoletoAutobus.Update(detalleBoleto);

                }

                await _unitOfWork.SaveAsync();

                _unitOfWork.Commit();

                 return "La venta de boleto, ha sido registrado exitosamente";

               
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                var message = ex.Message;
                throw new Exception($"Error: {message}");

            }
        }
    }
}
