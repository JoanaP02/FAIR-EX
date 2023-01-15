using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;

namespace Fair_ex.Services
{
    public class ClienteService
    {
        public ClienteService()
        {
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var clientes = await connection.QueryAsync<Cliente, Produto, Cliente>(
                "SELECT c.*, p.* FROM Cliente c JOIN Carrinho ca ON c.username = ca.Cliente_username JOIN Produtos p ON ca.Produto_idProduto = p.idProduto",
                (cliente, produto) =>
                {
                    cliente.Carrinho = cliente.Carrinho ?? new List<Produto>();
                    cliente.Carrinho.Add(produto);
                    return cliente;
                },
                splitOn: "username,idProduto"
            );
            return clientes.Distinct().ToList();
        }


        public async Task<ActionResult<Cliente>> GetCliente(string username)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var cliente = await connection.QueryFirstAsync<Cliente>("SELECT * FROM Cliente WHERE username = @Username",
                new { Username = username });

            if (cliente == null)
                return null;

            var carrinho = await connection.QueryAsync<Produto>("SELECT Produtos.* FROM Produtos" +
                "INNER JOIN Carrinho ON Produtos.idProduto = Carrinho.Produto_idProduto" +
                "WHERE Carrinho.Cliente_username = @Username", new { Username = username });

            cliente.Carrinho = carrinho.ToList();
            return cliente;
        }

        public async void CreateCliente(Cliente c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("insert into Cliente (username,password,Morada,numCartao,numTelemovel, cartaoVal,cartaoCCV, email)" +
                " values(@Username, @Password, @Morada, @NumCartao, @Telemovel, @ValCartao, @CCV, @Email)",
                new
                {
                    Username = c.Username,
                    Password = c.Password,
                    Morada = c.Morada,
                    NumCartao = c.Cartao,
                    Telemovel = c.Telemovel,
                    valCartao = c.validade,
                    CCV = c.CCV,
                    Email = c.Email
                });
        }

        public async void UpdateCliente(Cliente c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                await connection.ExecuteAsync("UPDATE Cliente SET password = @password, morada = @morada, telemovel = @telemovel, cartao = @cartao, cCV = @cCV, email = @email, validade = @validade WHERE username = @username", c, transaction);
                await connection.ExecuteAsync("DELETE FROM Carrinho WHERE Cliente_username = @username", new { c.Username }, transaction);
                if (c.Carrinho != null)
                {
                    var carrinho = c.Carrinho.Select(p => new { Cliente_username = c.Username, Produto_idProduto = p.Id });
                    await connection.ExecuteAsync("INSERT INTO Carrinho (Cliente_username, Produto_idProduto) VALUES (@Cliente_username, @Produto_idProduto)", carrinho, transaction);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }


        public async void DeleteCliente(string username)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from Cliente where username = @Username",
                new { Username = username });
        }
    }
}
