namespace Fair_ex.Models
{
    public class Categoria
    {
        public Categoria(string Nome,Tema Tema)
        {
            this.Nome = Nome;
            this.Tema = new Tema(Tema);
        }
        public string Nome { get; set; }
        public Tema Tema { get; set; }
    }
}
