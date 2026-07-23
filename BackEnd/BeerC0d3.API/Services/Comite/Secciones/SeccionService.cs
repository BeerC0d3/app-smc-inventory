using BeerC0d3.API.Dtos.Comite.Seccion;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Interfaces;

namespace BeerC0d3.API.Services.Comite.Secciones
{
    public class SeccionService : ISeccionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeccionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddUpdate(SeccionAddUpdateDto seccionDto, int userId)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                var seccion = await _unitOfWork.Secciones.GetSeccionByUserAsync(userId, seccionDto.Id);
                if (seccion == null)
                {
                    seccion = new Seccion();
                    seccion.FechaAlta = DateTime.Now;
                    seccion.Activo = true;
                }


                seccion.Nombre = seccionDto.Nombre;
                seccion.UsuarioAlta = userId.ToString();

                if (seccion.Id == 0)
                    _unitOfWork.Secciones.Add(seccion);
                else
                    _unitOfWork.Secciones.Update(seccion);

                await _unitOfWork.SaveAsync();

                if (seccion.UsuarioSecciones == null)
                {
                    seccion.UsuarioSecciones = new List<UsuarioSeccion>();
                    var userSeccion = new UsuarioSeccion();
                    userSeccion.SeccionId = seccion.Id;
                    userSeccion.UsuarioId = userId;
                    seccion.UsuarioSecciones.Add(userSeccion);
                }

                await _unitOfWork.SaveAsync();

                _unitOfWork.Commit();

                return $"La sección  {seccionDto.Nombre} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                var message = ex.Message;
                throw new Exception($"Error: {message}");

            }
        }

        public Task<ICollection<SeccionDto>> GetActives()
        {
            throw new NotImplementedException();
        }
    }
}
