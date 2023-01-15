using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Fair_ex.Controllers;
using Fair_ex.Models;
using Fair_ex.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Fair_ex.Pages
{
    public class ProductsModel : PageModel
    {

        public ProductsModel()
        {
            Result = new List<Feira>();
            ResultString = string.Join(",", Result);


        }

        public List<Feira> Result { get; set; }
        public string ResultString { get; set; }

        public void OnGet()
        {
            Result = new List<Feira>();
            ResultString = string.Join(",", Result);

        }
        public void OnPostFazCenas()
        {

            fazCenas();
            ResultString = string.Join(",", Result);
        }

        public async void fazCenas()
        {
            FeiraService fc = new FeiraService();
            var result = await fc.GetAllFeiras();
            // get the list of products from the result
            Result = result;
        }




    }
}