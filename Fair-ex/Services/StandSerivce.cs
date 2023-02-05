using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class StandService
    {
        public StandService()
        {
        }
        public List<Stand> GetAllStands()
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            var stands = connection.Query<Stand>("select * from Stand");
            return stands.ToList();
        }
        public Stand GetStand(int idFeira, string NomeVendedor)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            var stand = connection.QueryFirst<Stand>("select * from Stand where (feira_idfeira = @Id and vendedor_username = @Vendedor)",
                new { Id = idFeira, Vendedor = NomeVendedor});
            return stand;
        }
        public void CreateStand(Stand s, int idFeira)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            connection.ExecuteAsync("insert into Stand (feira_idfeira, Vendedor_username, taxaAceitacao,taxaRejeicao,receita)" +
                " values(@IdFeira, @Vendedor, @TaxaAceitacao, @TaxaRejeicao, @Receita)",
                new { IdFeira = idFeira , Vendedor = s.Vendedor.Nome, TaxaAceitacao= s.Taxa_Aceitacao, TaxaReceicao= s.Taxa_rejeicao, Receita= s.Receita });
        }
        public  void UpdateStand(Stand s, int idFeira)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            connection.ExecuteAsync("update Stand set feira_idfeira= @Feira, Vendedor_username = @Vendedor, taxaAceitacao= @TaxaAceitacao, taxaRejeicao = @TaxaRejeicao,receita= @Receita",
                new { Feira = idFeira, Vendedor = s.Vendedor.Nome, TaxaAceitacao = s.Taxa_Aceitacao, TaxaReceicao = s.Taxa_rejeicao, Receita = s.Receita });
        }
        public  void DeleteStand(int idFeira, string NomeVendedor)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            connection.ExecuteAsync("delete from Stand  where (feira_idfeira = @Id and vendedor_username = @Vendedor)",
                new { Id = idFeira, Vendedor = NomeVendedor });
        }

    }
}
