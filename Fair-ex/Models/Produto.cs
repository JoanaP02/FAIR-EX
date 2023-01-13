namespace Fair_ex.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        //public List<ImagemURL>? Imagens { get; set; }
        public List<string>? Imagens { get; set; }

        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Stock { get; set; }
    }
}
