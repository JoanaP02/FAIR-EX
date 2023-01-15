namespace Fair_ex.Models
{
    public class Tema
    {

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

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Categoria>? Categorias { get; set; }
    }
}
