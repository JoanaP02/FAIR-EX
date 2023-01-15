using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Categoria
    {
        public Categoria(string Nome,Tema Tema)
        {
            this.Nome = Nome;
            this.Tema = new Tema(Tema);
        }
        [Column("idcategoria")]
        public string Nome { get; set; }
        [Column("tema_tema")]
        public Tema Tema { get; set; }
        [Column("imagem")]
        public string imagem { get; set; }
    }
}
