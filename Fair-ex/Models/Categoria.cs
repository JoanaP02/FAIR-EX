namespace Fair_ex.Models
{
    public class Categoria
    {
        public Categoria(string Nome,string Tema)
        {
            this.Nome = Nome;
            this.Tema = Tema;
        }
        public string Nome { get; set; }
        public string Tema { get; set; }
    }
}
