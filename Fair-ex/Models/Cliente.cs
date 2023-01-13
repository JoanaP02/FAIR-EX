namespace Fair_ex.Models
{
    public class Cliente
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Morada { get; set; }
        public int Telemovel { get; set; }
        public int Cartao { get; set; }
        public List<Produto> Carrinho {get; set;}
    }
}
