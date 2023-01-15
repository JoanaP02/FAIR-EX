using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Fair_ex.Services
{
    public class CategoriaService
    {
        public CategoriaService()
        {
        }

        public async Task<List<Categoria>> GetAllCategorias()
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var query = @"SELECT c.idcategoria,c.imagem, t.nome, t.descricao, t.imagem
              FROM categoria c 
              JOIN tema t ON c.tema_tema = t.nome; ";

            var categorias = await connection.QueryAsync<Categoria, Tema, Categoria>(query, (f, t) =>
            {
                f.Tema = t;
                return f;
            }, splitOn: "nome").ConfigureAwait(false);
            return categorias.ToList();
        }

        public async Task<Categoria> GetCategoria(string id)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var query = @"SELECT c.idcategoria,c.imagem, t.nome, t.descricao, t.imagem
              FROM categoria c 
              JOIN tema t ON c.tema_tema = t.nome WHERE c.idcategoria = @Id";

            var categorias = await connection.QueryAsync<Categoria, Tema, Categoria>(query, (f, t) =>
            {
                f.Tema = t;
                return f;
            }, new { id }, splitOn: "nome").ConfigureAwait(false);
            return categorias.FirstOrDefault();
        }



        public async void CreateCategoria(Categoria c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var tema = c.Tema;
            var existingTema = await connection.QueryFirstOrDefaultAsync<Tema>("select * from tema where nome = @nome",
                new { nome = tema.Nome });
            if (existingTema == null)
            {
                await connection.ExecuteAsync("insert into tema (nome, descricao,imagem) values(@nome, @descricao,@imagem)",
                    new { nome = tema.Nome, descricao = tema.Descricao , imagem=tema.Imagem});
            }
            await connection.ExecuteAsync("insert into categoria (idcategoria, tema_tema, imagem) values(@idcategoria, @tema_tema,@imagem)",
                new { idcategoria = c.Nome, tema_tema = tema.Nome ,imagem=c.imagem});
        }


        public async void UpdateCategoria(Categoria c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
          
            var tema = c.Tema;
            await connection.ExecuteAsync("update tema set nome= @nome, descricao= @descricao, imagem =@imagem where nome= @tema_nome",
                new { nome = tema.Nome, descricao = tema.Descricao,imagem =tema.Imagem, tema_nome = tema.Nome });
            await connection.ExecuteAsync("update categoria set idcategoria= @idcategoria, tema_tema= @tema_tema, imagem = @imagem where idcategoria= @id",
                new { idcategoria = c.Nome, tema_tema = tema.Nome,imagem = c.imagem, id = c.Nome});
        }



        public async void DeleteCategoria(string id)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from categoria where idcategoria= @Id",
                new { Id = id });
        }

    }
}
