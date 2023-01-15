namespace Fair_ex.Models
{
    public class Produto
    {
        public Produto(int Id,string Nome,Categoria Categoria,string Descricao,int Preco,int Stock,int IdFeira, string User)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Categoria = Categoria;
            this.Descricao = Descricao;
            this.Preco = Preco;
            this.Stock = Stock;
            this.IdFeira = IdFeira;
            this.UsernameVendedor = User;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        //public List<ImagemURL>? Imagens { get; set; }
        public List<string>? Imagens { get; set; }

        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Stock { get; set; }
        public int IdFeira { get; set; }
        public string UsernameVendedor { get; set; }

        public override string ToString() { return this.Nome; }
    }
}
