using ApiRepasoExamenCubos.Data;
using ApiRepasoExamenCubos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRepasoExamenCubos.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context) {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync() {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<List<string>> GetMarcasAsync() {
            return await this.context.Cubos
                             .Select(c => c.Marca)
                             .Distinct()
                             .ToListAsync();
        }

        public async Task<List<Cubo>> GetCubosMarcaAsync(string marca) {
            return await this.context.Cubos
                .Where(c => c.Marca == marca)
                .ToListAsync();
        }

        public async Task<Cubo> FindCuboAsync(int id) {
            return await this.context.Cubos.FindAsync(id);
        }

        public async Task CreateCuboAsync(string nombre, string modelo, string marca, string imagen, int precio) {
            int newId = this.context.Cubos.Max(c => c.IdCubo) + 1;
            Cubo cubo = new Cubo()
            {
                IdCubo = newId,
                Nombre = nombre,
                Modelo = modelo,
                Marca = marca,
                Imagen = imagen,
                Precio = precio
            };
            this.context.Cubos.Add(cubo);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCuboAsync(int id, Cubo cubo) {
            Cubo cuboOrigin = await this.context.Cubos.FindAsync(id);
            if (cuboOrigin != null) {
                cuboOrigin.Nombre = cubo.Nombre;
                cuboOrigin.Modelo = cubo.Modelo;
                cuboOrigin.Marca = cubo.Marca;
                cuboOrigin.Imagen = cubo.Imagen;
                cuboOrigin.Precio = cubo.Precio;
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteCuboAsync(int id) {
            Cubo cubo = await this.context.Cubos.FindAsync(id);
            if (cubo != null) {
                this.context.Cubos.Remove(cubo);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
