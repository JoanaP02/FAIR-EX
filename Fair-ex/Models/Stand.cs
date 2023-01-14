namespace Fair_ex.Models
{
    public class Stand
    {
        public int Id { get; set; }
        public Vendedor Vendedor { get; set; }
        public Tema Tema { get; set; }
        public int Taxa_Aceitacao { get; set; }
        public int Taxa_rejeicao { get; set; }
        public List<Produto>? Produtos { get; set; }
        public float Receita { get; set; }
    }
}
