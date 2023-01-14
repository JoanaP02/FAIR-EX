using Dapper;
using Fair_ex.Models;
using Fair_ex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("categoria/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private CategoriaService service;
        public CategoriaController(IConfiguration config)
        {
            service = new CategoriaService(config);
        }
        [HttpGet]
        public Task<ActionResult<List<Categoria>>> GetAllCategorias()
        {
            return service.GetAllCategorias();
        }
        [HttpGet("{idcategoria}")]
        public Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            return service.GetCategoria(id);
        }
        [HttpPost]
        public async void CreateCategoria(Categoria c)
        {
            service.CreateCategoria(c);
        }
        [HttpPut]
        public async void UpdateCategoria(Categoria c)
        {
            service.UpdateCategoria(c);
        }
        [HttpDelete("{idcategoria}")]
        public async void DeleteCategoria(int id)
        {
            service.DeleteCategoria(id);
        }

    }
}
