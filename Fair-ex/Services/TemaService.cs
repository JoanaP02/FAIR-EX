using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class TemaService
    {
        public TemaService()
        {
        }
        public async Task<List<Tema>> GetAllTemas()
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            var temas = await connection.QueryAsync<Tema>("select * from tema");
            return temas.ToList();
        }
        public Tema GetTema(string nome)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            var tema = connection.QueryFirst<Tema>("select nome,descricao,imagem from tema where nome= @Nome",
                new { Nome = nome });
            Console.WriteLine(tema.Nome);
            Console.WriteLine(tema.Imagem);
            return tema;
        }
        public async void CreateTema(Tema t)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("insert into tema (nome, descricao,imagem)" +
                " values(@Nome, @Descricao,@Imagem)",
                new { Nome = t.Nome, Descricao = t.Descricao, Imagem = t.Imagem });
        }
        public async void UpdateTema(Tema t)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("update tema set nome= @Nome, descricao= @Descricao, imagem = @Imagem",
                new { Nome = t.Nome, Descricao = t.Descricao, Imagem=t.Imagem});
        }
        public async void DeleteTema(string nome)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEXDB;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from tema where nome= @Nome",
                new { Nome = nome });
        }

    }
}
