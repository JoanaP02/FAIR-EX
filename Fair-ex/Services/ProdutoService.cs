using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Hosting.Server;

namespace Fair_ex.Services
{
    public class ProdutoService
    {
        private readonly IConfiguration _config;
        public ProdutoService()
        {
           // _config = config;
        }
        
        public async Task<List<Produto>> GetAllProdutos()
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var query = @"SELECT p.idProduto, p.Nome, p.Descricao, p.Preco,p.Stand_nome, p.Stand_Vendedor_username, c.idcategoria, c.imagem
              FROM Produtos p 
              JOIN categoria c ON p.categoria_idcategoria = c.idcategoria; ";

            var produtos = await connection.QueryAsync<Produto, Categoria, Produto>(query, (f, t) =>
            {
                f.Categoria = t;
                return f;
            }, splitOn: "idcategoria").ConfigureAwait(false);
            return produtos.ToList();
        }
        
        public async Task<Produto> GetProduto(int idProduto)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var query = @"SELECT p.idProduto, p.Nome, p.Descricao, p.Preco,p.Stand_nome, p.Stand_Vendedor_username, c.idcategoria, c.imagem
              FROM Produtos p 
              JOIN categoria c ON p.categoria_idcategoria = c.idcategoria WHERE p.idPrduto=@Id ";

            var produtos = await connection.QueryAsync<Produto, Categoria, Produto>(query, (f, t) =>
            {
                f.Categoria = t;
                return f;
            }, new { idProduto }, splitOn: "idcategoria").ConfigureAwait(false);
            return produtos.FirstOrDefault();
        }

   
        
        public async void CreateProduto(Produto p)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            Categoria c = p.Categoria;
            var result = GetProduto(p.Id);
            if (result == null)
            {
                await connection.ExecuteAsync("insert into Produtos (idProduto, Nome, categoria_idcategoria,Descricao,Preco, Stand_Vendedor_username)" +
                " values(@Id, @Nome, @Categoria, @Descricao, @Preco, @Idfeira, @Username)",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria.Idcategoria, Descricao = p.Descricao, Preco = p.Preco, Username = p.UsernameVendedor });
            }
        }
        
        public async void UpdateProduto(Produto p)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            Categoria c = p.Categoria;
            CategoriaService cs = new CategoriaService();
            cs.UpdateCategoria(c);
            await connection.ExecuteAsync("update Produtos set idProduto= @Id, Nome= @Nome, categoria_idcategoria=@Categoria,Descricao=@Descricao,Preco=@Preco, Stand_Vendedor_username= @Username",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria.Idcategoria, Descricao = p.Descricao, Preco = p.Preco, Username = p.UsernameVendedor });
        }
        
        public async void DeleteProduto(int idProduto)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from Produtos where idProduto = @Id",
                new { Id = idProduto });
        }
    }
}
