using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Cliente
    {
        public Cliente(string username, string password, string morada, int telemovel, int cartao, int cCV, string email, List<Produto>? carrinho, DateTime validade)
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
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("Morada")]
        public string Morada { get; set; }
        [Column("numTelemovel")]
        public int Telemovel { get; set; }
        [Column("numCartao")]
        public int Cartao { get; set; }
        [Column("cartaoCVV")]
        public int CCV { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("cartaoValidade")]
        public DateTime validade { get; set; }
        public List<Produto>? Carrinho {get; set;}
    }
}
