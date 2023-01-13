namespace Fair_ex.wwwroot.Models
{
    public class Stand
    {
        public Vendedor MyProperty { get; set; }
        public float Taxa_Aceitacao { get; set; }
        public float Taxa_rejeicao { get; set; }
        public List<Produto> produtos { get; set; }
        public float receita { get; set; }
    }
}
