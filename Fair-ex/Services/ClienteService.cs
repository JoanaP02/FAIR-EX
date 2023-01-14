using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;

namespace Fair_ex.Services
{
    public class ClienteService
    {
        private readonly IConfiguration _config;
        public ClienteService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var clientes = await connection.QueryAsync<Cliente>("select * from Cliente");
            return clientes.ToList();
        }

        public async Task<ActionResult<Cliente>> GetCliente(string username)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cliente = await connection.QueryFirstAsync<Cliente>("select * from Cliente where username = @Username",
                new { Username = username });
            return  cliente;
        }

        public async void CreateCliente(Cliente c)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
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
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update Cliente set username=@Username, password=@Password, Morada=@Morada, numCartao=@NumCartao," +
                "       numTelemovel = @Telemovel, cartaoCCV=@CCV, email=@Email)",
                new
                {
                    Username = c.Username,
                    Password = c.Password,
                    Morada = c.Morada,
                    NumCartao = c.Cartao,
                    Telemovel = c.Telemovel,
                    CCV = c.CCV,
                    Email = c.Email
                });
        }
        
        public async void DeleteCliente(string username)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Cliente where username = @Username",
                new { Username = username });
        }
    }
}
