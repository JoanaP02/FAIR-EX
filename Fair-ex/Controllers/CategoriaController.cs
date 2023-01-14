using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly IConfiguration _config;
        public CategoriaController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAllCategorias()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var produtos = await connection.QueryAsync<Produto>("select * from categoria");
            return Ok(produtos);
        }
        [HttpGet("{idcategoria}")]
        public async Task<ActionResult<Vendedor>> GetCategoria(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var categoria = await connection.QueryFirstAsync<Produto>("select * from categoria where idcategoria= @Id",
                new { Id = id });
            return Ok(categoria);
        }
        [HttpPost]
        public async void CreateCategoria(Categoria c)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into categoria (idcategoria, tema)" +
                " values(@idcategoria, @tema)",
                new {idcategoria = c.Nome, tema = c.Tema});
        }
        [HttpPut]
        public async void UpdateCategoria(Categoria c)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update categoria set idcategoria= @idcategoria, tema= @tema",
                new { idcategoria = c.Nome, tema = c.Tema});
        }
        [HttpDelete("{idcategoria}")]
        public async void DeleteCategoria(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from categoria where idcategoria= @Id",
                new { Id = id });
        }

    }
}
