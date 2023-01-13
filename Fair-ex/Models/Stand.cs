namespace Fair_ex.wwwroot.Models
{
    public class Stand
    {
        public int Id { get; set; }
        public Vendedor vendedor { get; set; }
        public Tema tema { get; set; }
        public int Taxa_Aceitacao { get; set; }
        public int Taxa_rejeicao { get; set; }
        public List<Produto>? produtos { get; set; }
        public float receita { get; set; }
    }
}
