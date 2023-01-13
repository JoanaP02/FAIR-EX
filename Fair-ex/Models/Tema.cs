namespace Fair_ex.Models
{
    public class Tema
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Categoria>? Categorias { get; set; }
    }
}
