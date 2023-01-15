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

        public string Nome { get; set; }
        public string Password { get; set; }
        public int Telemovel { get; set; }
        public string Morada { get; set; }
        public string IBAN { get; set; }
        public int Avaliacao { get; set; }
        public int ReceitaTotal { get; set; }
        public string Email { get; set; }
    }
}
