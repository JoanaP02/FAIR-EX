using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("tema/[controller]")]
    [ApiController]
    public class TemaController : Controller
    {
        private readonly IConfiguration _config;
        public TemaController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tema>>> GetAllTemas()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var temas = await connection.QueryAsync<Produto>("select * from tema");
            return Ok(temas);
        }
        [HttpGet("{nome}")]
        public async Task<ActionResult<Tema>> GetTema(string nome)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var tema = await connection.QueryFirstAsync<Produto>("select * from tema where nome= @Nome",
                new { Nome = nome });
            return Ok(tema);
        }
        [HttpPost]
        public async void CreateTema(Tema t)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into tema (nome, descricao)" +
                " values(@Nome, @Descricao)",
                new { Nome = t.Nome, Descricao = t.Descricao });
        }
        [HttpPut]
        public async void UpdateTema(Tema t)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update tema set nome= @Nome, descricao= @Descricao",
                new { Nome= t.Nome, Descricao = t.Descricao });
        }
        [HttpDelete("{idcategoria}")]
        public async void DeleteTema(string nome)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from tema where nome= @Nome",
                new { Nome = nome});
        }

    }
}
