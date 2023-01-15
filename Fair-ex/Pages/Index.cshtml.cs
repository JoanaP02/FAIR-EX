using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fair_ex.Models;
using Fair_ex.Services;

namespace Fair_ex.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IList<Stand> stands { get; set; }
        public Tema tema { get; set; }
        public StandService standService { get; set; }
        public TemaService temaService { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            standService = new StandService();
            temaService = new TemaService();

        }


        public void OnGet()
        {
            stands = standService.GetAllStands();
            tema = temaService.GetTema("Casa e Jardim");

        }
    }
}