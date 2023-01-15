using Fair_ex.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Fair_ex.Services;

namespace Fair_ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeiraController : Controller
    {
        private FeiraService service;
        public FeiraController(IConfiguration config)
        {
            service = new FeiraService(config);
        }
        [HttpGet]
        public async Task<ActionResult<List<Feira>>> GetAllFeiras()
        {
            return Ok(service.GetAllFeiras());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Feira>> GetFeira(int id)
        {
            return Ok(service.GetFeira(id));
        }
        [HttpPost]
        public async void CreateFeira(Feira f)
        {
            service.CreateFeira(f);
        }
        [HttpPut]
        public async void UpdateFeira(Feira f)
        {
            service.UpdateFeira(f);
        }
        [HttpDelete("{id}")]
        public async void DeleteFeira(int id)
        {
            service.DeleteFeira(id);
        }

    }
}
