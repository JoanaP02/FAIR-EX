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
            var query = @"SELECT * FROM Produtos; 
                  SELECT * FROM categoria";
            using (var multi = connection.QueryMultiple(query))
            {
                var produtos = multi.Read<Produto>().ToList();
                var categorias = multi.Read<Categoria>().ToList();
                produtos.ForEach(p => p.Categoria = categorias.FirstOrDefault(c => c.Nome == p.Categoria.Nome));
                Console.WriteLine();
                return produtos;
            }
        }
        
        public async Task<Produto> GetProduto(int idProduto)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var query = @"SELECT * FROM Produtos WHERE idProduto = @id; 
                  SELECT * FROM categoria WHERE idcategoria = (SELECT categoria_idcategoria FROM Produtos WHERE idProduto = @id)";
            var parameters = new { id = idProduto };
            using (var multi = connection.QueryMultiple(query, parameters))
            {
                var produto = multi.Read<Produto>().FirstOrDefault();
                var categoria = multi.Read<Categoria>().FirstOrDefault();
                produto.Categoria = categoria;
                return produto;
            }
          }

   
        
        public async void CreateProduto(Produto p)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            Categoria c = p.Categoria;
            CategoriaService cs = new CategoriaService(_config);
            cs.CreateCategoria(c);
            var result = GetProduto(p.Id);
            if (result == null)
            {
                await connection.ExecuteAsync("insert into Produtos (idProduto, Nome, categoria_idcategoria,Descricao,Preco, Stand_feira_idfeira, Stand_Vendedor_username)" +
                " values(@Id, @Nome, @Categoria, @Descricao, @Preco, @Idfeira, @Username)",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria.Nome, Descricao = p.Descricao, Preco = p.Preco, IdFeira = p.IdFeira, Username = p.UsernameVendedor });
            }
        }
        
        public async void UpdateProduto(Produto p)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            Categoria c = p.Categoria;
            CategoriaService cs = new CategoriaService(_config);
            cs.UpdateCategoria(c);
            await connection.ExecuteAsync("update Produtos set idProduto= @Id, Nome= @Nome, categoria_idcategoria=@Categoria,Descricao=@Descricao,Preco=@Preco, Stand_feira_idfeira= @IdFeira, Stand_Vendedor_username= @Username",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria.Nome, Descricao = p.Descricao, Preco = p.Preco, IdFeira = p.IdFeira, Username = p.UsernameVendedor });
        }
        
        public async void DeleteProduto(int idProduto)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from Produtos where idProduto = @Id",
                new { Id = idProduto });
        }
    }
}
