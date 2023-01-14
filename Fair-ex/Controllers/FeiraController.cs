using Fair_ex.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Fair_ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeiraController : Controller
    {
        private readonly IConfiguration _config;
        public FeiraController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Feira>>> GetAllFeiras()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var feiras = await connection.QueryAsync<Feira>("select * from feira");
            return Ok(feiras);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Feira>> GetFeira(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var feira = await connection.QueryFirstAsync<Feira>("select * from feira where id = @Id",
                new { Id = id});
            return Ok(feira);
        }
        [HttpPost]
        public async void CreateFeira(Feira f)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into feira (idfeira,tema_tema,dataDeInicioInscricao,dataDeFimInscricao,dataComeco,dataTermino)" +
                " values(@Id, @Tema, @DII, @DFI, @DC, @DT)",
                new
                {
                    Id = f.Id,
                    Tema = f.Tema.Nome,
                    DII = f.DataIncricaoIninio,
                    DFI = f.DataIncricaoFim,
                    DC = f.DataComecoInicio,
                    DT = f.DataComecoFim
                });
        }
        [HttpPut]
        public async void UpdateFeira(Feira f)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update feira set idfeira=@Id, tema_tema=@Tema, dataDeInicioInscricao=@DII," +
                "dataDeFimInscricao= @DFI,dataComeco= @DC, dataTermino=@DT)",
                new
                {
                    Id = f.Id,
                    Tema = f.Tema.Nome,
                    DII = f.DataIncricaoIninio,
                    DFI = f.DataIncricaoFim,
                    DC = f.DataComecoInicio,
                    DT = f.DataComecoFim
                });
        }
        [HttpDelete("{id}")]
        public async void DeleteFeira(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from feira where idfeira = @Id",
                new { Id = id });
        }

    }
}
