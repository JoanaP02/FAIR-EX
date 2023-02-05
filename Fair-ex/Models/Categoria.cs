using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Categoria
    {
        public Categoria()
        {

        }

        public Categoria(string Nome)
        {
            this.Idcategoria = Nome;
        }
        public Categoria(string Nome,Tema Tema)
        {
            this.Idcategoria = Nome;
            this.Tema = new Tema(Tema);
        }
        [Column("idcategoria")]
        public string Idcategoria { get; set; }
        [Column("tema_tema")]
        public Tema Tema { get; set; }
        [Column("imagem")]
        public string imagem { get; set; }
    }
}
