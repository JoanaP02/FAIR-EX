using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Produto
    {
        public Produto(int Id,string Nome,Categoria Categoria,string Descricao,int Preco, string User)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Categoria = Categoria;
            this.Descricao = Descricao;
            this.Preco = Preco;
            this.UsernameVendedor = User;
        }
        [Column("idProduto")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }

        public Categoria Categoria { get; set; }
        [Column("imagem")]
        public string Imagem { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Preco")]
        public int Preco { get; set; }

        [Column("Stand_Vendedor_username")]
        public string UsernameVendedor { get; set; }

        public override string ToString() { return this.Nome; }
    }
}
