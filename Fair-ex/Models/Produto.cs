namespace Fair_ex.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria categoria { get; set; }
        public List<ImagemURL>? imagens { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Stock { get; set; }
    }
}
