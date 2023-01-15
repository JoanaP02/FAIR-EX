using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Stand
    {
        public Stand(Vendedor vendedor, int taxa_Aceitacao, int taxa_rejeicao, List<Produto>? produtos, float receita)
        {
            Vendedor = vendedor;
            Taxa_Aceitacao = taxa_Aceitacao;
            Taxa_rejeicao = taxa_rejeicao;
            Produtos = produtos;
            Receita = receita;
        }
        [Column("nome")]
        public string nome { get; set; }
        [Column("descricao")]
        public string descricao { get; set; }

        [Column("taxaAceitacao")]
        public int Taxa_Aceitacao { get; set; }
        [Column("taxaRejeicao")]
        public int Taxa_rejeicao { get; set; }
        [Column("receita")]
        public float Receita { get; set; }
        [Column("imagem")]
        public string imagem { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<Produto>? Produtos { get; set; }
    }
}
