using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext con)
        {
            this.context = con;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<int> MaxIdPersonajeAsync()
        {
            return await this.context.Personajes.MaxAsync(x => x.IdPersonaje);
        }

        public async Task CreatePersonaje (string nombre, string imagen)
        {
            Personaje p = new Personaje();
            p.IdPersonaje = await MaxIdPersonajeAsync() + 1;
            p.Nombre = nombre;
            p.Imagen = imagen;

            await this.context.Personajes.AddAsync(p);
            await this.context.SaveChangesAsync();
        }

        public async Task<Personaje> FindPersonajeById(int id)
        {
            return await this.context.Personajes.Where(x => x.IdPersonaje == id).FirstOrDefaultAsync();
        }

        public async Task UpdatePersonaje(int idpersonaje ,string nombre, string imagen)
        {
            Personaje p = await FindPersonajeById(idpersonaje);
            p.Nombre = nombre;
            p.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }
    }
}
