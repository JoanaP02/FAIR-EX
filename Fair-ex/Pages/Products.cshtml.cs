using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Fair_ex.Controllers;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Fair_ex.Pages
{
    public class ProductsModel : PageModel
    {

        public ProductsModel()
        {
            Result = new List<Produto>();
            ResultString = string.Join(",", Result);


        }

        public List<Produto> Result { get; set; }
        public string ResultString { get; set; }

        public void OnGet()
        {
            Result = new List<Produto>();
            ResultString = string.Join(",", Result);

        }
        public void OnPostFazCenas()
        {

            fazCenas();
            ResultString = string.Join(",", Result);
        }

        public async void fazCenas()
        {
            ProdutoController pc = new ProdutoController();
            Categoria newC = new Categoria("aaa2", "bbbb");
            Produto newP = new Produto(1, "prod", newC, "", 0, 0, 1, "");
            pc.CreateProduto(newP);
            var result = await pc.GetAllProdutos();
            // get the list of products from the result
            Result = result.Value;
        }

        public void fazCenas2()
        { Console.WriteLine("FUNCIONA"); }



    }
}