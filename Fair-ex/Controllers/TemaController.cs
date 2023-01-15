using Dapper;
using Fair_ex.Models;
using Fair_ex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("tema/[controller]")]
    [ApiController]
    public class TemaController : Controller
    {
        private TemaService service;
        public TemaController( )
        {
            service = new TemaService();
        }
        [HttpGet]
        public async Task<ActionResult<List<Tema>>> GetAllTemas()
        {
            return Ok(service.GetAllTemas());
        }
        [HttpGet("{nome}")]
        public async Task<ActionResult<Tema>> GetTema(string nome)
        {
            return Ok(service.GetTema(nome));
        }
        [HttpPost]
        public async void CreateTema(Tema t)
        {
            service.CreateTema(t);
        }
        [HttpPut]
        public async void UpdateTema(Tema t)
        {
            service.UpdateTema(t);
        }
        [HttpDelete("{idcategoria}")]
        public async void DeleteTema(string nome)
        {
            service.DeleteTema(nome);
        }

    }
}
