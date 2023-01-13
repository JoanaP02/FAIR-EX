namespace Fair_ex.Models
{
    public class Tema
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public List<Categoria>? categorias { get; set; }
    }
}
