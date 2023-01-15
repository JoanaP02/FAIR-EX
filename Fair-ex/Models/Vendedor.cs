using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Vendedor
    {
        public Vendedor(string nome, string password, int telemovel, string morada, string iBAN, int avaliacao, int receitaTotal, string email)
        {
            Nome = nome;
            Password = password;
            Telemovel = telemovel;
            Morada = morada;
            IBAN = iBAN;
            Avaliacao = avaliacao;
            ReceitaTotal = receitaTotal;
            Email = email;
        }
        [Column("username")]
        public string Nome { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("telemovel")]
        public int Telemovel { get; set; }
        [Column("morada")]
        public string Morada { get; set; }
        [Column("IBAN")]
        public string IBAN { get; set; }
        [Column("avaliacao")]
        public int Avaliacao { get; set; }
        [Column("receitaTotal")]
        public int ReceitaTotal { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("imagem")]
        public string imagem { get; set; }
    }
}
