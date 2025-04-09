using ApiRepasoExamenCubos.Models;
using ApiRepasoExamenCubos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRepasoExamenCubos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;
        public CubosController(RepositoryCubos repo) {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cubo>>> GetCubos() {
            List<Cubo> cubitos = await this.repo.GetCubosAsync();
            return cubitos;
        }

        [HttpGet("Marcas")]
        public async Task<ActionResult<List<string>>> GetMarcas() {
            List<string> marcas = await this.repo.GetMarcasAsync();
            return marcas;
        }

        [HttpGet("Marcas/{marca}")]
        public async Task<ActionResult<List<Cubo>>> GetCubosMarca(string marca) {
            List<Cubo> cubitos = await this.repo.GetCubosMarcaAsync(marca);
            return cubitos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cubo>> FindCubo(int id) {
            return await this.repo.FindCuboAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCubo(Cubo cubo) {
            await this.repo.CreateCuboAsync(cubo.Nombre, cubo.Modelo, cubo.Marca, cubo.Imagen, cubo.Precio);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCubo(int id, Cubo cubo) {
            await this.repo.UpdateCuboAsync(id, cubo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCubo(int id) {
            await this.repo.DeleteCuboAsync(id);
            return Ok();
        }
    }
}
