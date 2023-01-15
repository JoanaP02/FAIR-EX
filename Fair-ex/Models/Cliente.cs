namespace Fair_ex.Models
{
    public class Cliente
    {
        public Cliente(string username, string password, string morada, int telemovel, int cartao, int cCV, string email, List<Produto>? carrinho, string validade)
        {
            Username = username;
            Password = password;
            Morada = morada;
            Telemovel = telemovel;
            Cartao = cartao;
            CCV = cCV;
            Email = email;
            Carrinho = carrinho;
            this.validade = validade;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Morada { get; set; }
        public int Telemovel { get; set; }
        public int Cartao { get; set; }
        public int CCV { get; set; }
        public string Email { get; set; }
        public List<Produto>? Carrinho {get; set;}
        public string validade { get; set; }
    }
}
