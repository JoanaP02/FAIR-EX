using Fair_ex.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Fair_ex.Services;

namespace Fair_ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private ClienteService service;
        public ClienteController(IConfiguration config)
        {
            service = new ClienteService(config);
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllClientes()
        {
            return Ok(service.GetAllClientes());
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<Cliente>> GetCliente(string username)
        {
            return Ok(service.GetCliente(username));
        }
        [HttpPost]
        public async void CreateCliente(Cliente c)
        {
            service.CreateCliente(c);
        }
        [HttpPut]
        public async void UpdateCliente(Cliente c)
        {
            service.UpdateCliente(c);
        }
        [HttpDelete("{username}")]
        public async void DeleteCliente(string username)
        {
            service.DeleteCliente(username);
        }

    }
}
