using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Interfaces;

namespace BeerC0d3.API.Services.Comite.Personas
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddUpdate(PersonaAddUpdateDto model)
        {
            try
            {
                var persona = _unitOfWork.Persona
                .Find(item => item.Id == model.Id)
                .FirstOrDefault();

                if (persona == null)
                {
                    persona = new Persona();
                    persona.FechaAlta = DateTime.Now;
                    persona.Activo = true;
                }

                persona.seccionId = model.seccionId;
                persona.Nombre = model.Nombre;
                persona.Colonia = model.Colonia;
                persona.Calle = model.Callle;
                persona.Numero = model.Numero;
                persona.Latitud = model.Latitud;
                persona.Longitud = model.Longitud;

                if (persona.Id == 0)
                    _unitOfWork.Persona.Add(persona);
                else
                    _unitOfWork.Persona.Update(persona);


                await _unitOfWork.SaveAsync();


                return $"La persona  {model.Nombre} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {

                var message = ex.Message;
                throw new Exception($"Error: {message}");

            }
        }

        public async Task<string> CooperacionPersona(CooperacionPersonaDto model)
        {
            try
            {
              
                var cooperacion = new Cooperacion();
                cooperacion.Activo = true;
                cooperacion.PersonaId = model.personaId;
                cooperacion.PeriodoId = model.periodoId;
                cooperacion.Monto = model.Monto;
                cooperacion.FechaAlta = DateTime.Now;
                _unitOfWork.Cooperacion.Add(cooperacion);

                await _unitOfWork.SaveAsync();


                return $"El monto de la persona ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {

                var message = ex.Message;
                throw new Exception($"Error: {message}");

            }
        }
    }
}
