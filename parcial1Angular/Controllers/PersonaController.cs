using Microsoft.AspNetCore.Mvc;
using BLL;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace parcial1Angular.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PersonaController:ControllerBase{
            private readonly PersonaService personaService;
            public IConfiguration Configuration{
                get;
            }
            public PersonaController(IConfiguration configuration){
                Configuration = configuration;
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                personaService = new PersonaService(connectionString);
            }
            private Persona MapearPersona(PersonaInputModel personaInput){
                var persona = new Persona{
                    Identificacion = personaInput.Identificacion,
                    Nombre = personaInput.Nombre,
                    Apellido = personaInput.Apellido,
                    Sexo = personaInput.Sexo,
                    Edad = Convert.ToInt32(personaInput.Edad),
                    Departamento = personaInput.Departamento,
                    Ciudad = personaInput.Ciudad,
                    valorApoyoRecibido = personaInput.valorApoyoRecibido,
                    ModalidadApoyo = personaInput.ModalidadApoyo,
                    Fecha = personaInput.Fecha
                };
                return persona;
            }
            // post: api-persona
            [HttpPost]
            public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput){
                Persona persona = MapearPersona(personaInput);
                var response = personaService.Guardar(persona);
                if(response.Error){
                    return BadRequest(response.Mensaje);
                }
                return Ok(response.Persona);
            }
            // GET: api/Persona​
            [HttpGet]
            public ActionResult<PersonaViewModel> Gets()
            {
                var response = personaService.Consultar();
                if(response.Error)
                {
                    return BadRequest(response.Mensaje);
                }
                return Ok(response.Personas.Select(p=> new PersonaViewModel(p)));
            }
            }
}