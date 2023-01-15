using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class StandService
    {
        private readonly IConfiguration _config;
        public StandService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<Stand>> GetAllStands()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var stands = await connection.QueryAsync<Stand>("select * from Stand");
            return stands.ToList();
        }
        public async Task<Stand> GetStand(int idFeira, string NomeVendedor)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var stand = await connection.QueryFirstAsync<Stand>("select * from Stand where (feira_idfeira = @Id and vendedor_username = @Vendedor)",
                new { Id = idFeira, Vendedor = NomeVendedor});
            return stand;
        }
        public async void CreateStand(Stand s, int idFeira)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Stand (feira_idfeira, Vendedor_username, taxaAceitacao,taxaRejeicao,receita)" +
                " values(@IdFeira, @Vendedor, @TaxaAceitacao, @TaxaRejeicao, @Receita)",
                new { IdFeira = idFeira , Vendedor = s.Vendedor.Nome, TaxaAceitacao= s.Taxa_Aceitacao, TaxaReceicao= s.Taxa_rejeicao, Receita= s.Receita });
        }
        public async void UpdateStand(Stand s, int idFeira)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update Stand set feira_idfeira= @Feira, Vendedor_username = @Vendedor, taxaAceitacao= @TaxaAceitacao, taxaRejeicao = @TaxaRejeicao,receita= @Receita",
                new { Feira = idFeira, Vendedor = s.Vendedor.Nome, TaxaAceitacao = s.Taxa_Aceitacao, TaxaReceicao = s.Taxa_rejeicao, Receita = s.Receita });
        }
        public async void DeleteStand(int idFeira, string NomeVendedor)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Stand  where (feira_idfeira = @Id and vendedor_username = @Vendedor)",
                new { Id = idFeira, Vendedor = NomeVendedor });
        }

    }
}
