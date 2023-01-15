using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class FeiraService
    {
        private readonly IConfiguration _config;
        public FeiraService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<Feira>> GetAllFeiras()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var feiras = await connection.QueryAsync<Feira>("select * from feira");
            return feiras.ToList();
        }
        public async Task<Feira> GetFeira(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var feira = await connection.QueryFirstAsync<Feira>("select * from feira where id = @Id",
                new { Id = id });
            return feira;
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
        public async void DeleteFeira(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from feira where idfeira = @Id",
                new { Id = id });
        }

    }
}
