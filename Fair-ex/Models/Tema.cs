using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Tema
    {
        public Tema()
        {

        }

        public Tema(Tema tema)
        {
            this.Nome = tema.Nome;
            this.Descricao = tema.Descricao;
            this.Categorias= tema.Categorias;
        }

        public Tema(string nome, string descricao, List<Categoria>? categorias)
        {
            Nome = nome;
            Descricao = descricao;
            Categorias = categorias;
        }

        [Column("nome")]
        public string Nome { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("imagem")]
        public string Imagem { get; set; }
        public List<Categoria>? Categorias { get; set; }
    }
}
