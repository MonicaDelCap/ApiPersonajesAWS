using ApiPersonajesAWS.Models;
using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repository;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repository.GetPersonajesAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repository.CreatePersonaje(personaje.Nombre,personaje.Imagen);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Personaje>> FindPersonajeById(int id)
        {
            return await this.repository.FindPersonajeById(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repository.UpdatePersonaje( personaje.IdPersonaje,personaje.Nombre, personaje.Imagen);
            return Ok();
        }
    }
}
