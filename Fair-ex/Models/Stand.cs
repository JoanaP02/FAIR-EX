namespace Fair_ex.Models
{
    public class Stand
    {
        public Stand(Vendedor vendedor, Tema tema, int taxa_Aceitacao, int taxa_rejeicao, List<Produto>? produtos, float receita)
        {
            Vendedor = vendedor;
            Tema = tema;
            Taxa_Aceitacao = taxa_Aceitacao;
            Taxa_rejeicao = taxa_rejeicao;
            Produtos = produtos;
            Receita = receita;
        }

        public Vendedor Vendedor { get; set; }
        public Tema Tema { get; set; }
        public int Taxa_Aceitacao { get; set; }
        public int Taxa_rejeicao { get; set; }
        public List<Produto>? Produtos { get; set; }
        public float Receita { get; set; }
    }
}
