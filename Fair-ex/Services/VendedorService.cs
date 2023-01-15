using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class VendedorService
    {
        public VendedorService()
        {
        }
        public async Task<List<Vendedor>> GetAllVendedores()
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var vendedores = await connection.QueryAsync<Vendedor>("select * from Vendedor");
            return vendedores.ToList();
        }
        public async Task<Vendedor> GetVendedor(int username)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var vendedor = await connection.QueryFirstAsync<Vendedor>("select * from Vendedor where username = @Id",
                new { Id = username });
            return vendedor;
        }
        public async void CreateVendedor(Vendedor v)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("insert into Vendedor (username, password, morada,telemovel,IBAN, avaliacao, receitaTotal, email,imagem)" +
                " values(@Username, @Password, @Morada, @Telemovel, @IBAN, @Avaliacao, @ReceitaTotal, @Email,  @Imagem)",
                new { Username = v.Nome, Password = v.Password, Morada = v.Morada, Telemovel = v.Telemovel, IBAN = v.IBAN,
                    Avaliacao = v.Avaliacao, ReceitaTotal = v.Email,Imagem = v.imagem });
        }
        public async void UpdateVendedor(Vendedor v)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("update Vendedor set username= @Username, password = @Password, morada= @Morada, telemovel= @Telemovel,IBAN= @IBAN, avaliacao=@Avaliacao, receitaTotal= @ReceitaTotal, email= @Email, imagem=@Imagem",
                new { Username = v.Nome, Password = v.Password, Morada = v.Morada, Telemovel = v.Telemovel, IBAN = v.IBAN, Avaliacao = v.Avaliacao, ReceitaTotal = v.Email, Imagem = v.imagem });
        }
        public async void DeleteVendedor(int username)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from Vendedor where username = @Id",
                new { Id = username });
        }

    }
}
