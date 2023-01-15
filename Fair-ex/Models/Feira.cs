namespace Fair_ex.Models
{
    public class Feira
    {
        public Feira(int Id, Tema Tema, string DataInscricao, string DataInscricaoFim, string DataInicio, string DataFim)
        {
            this.Id = Id;
            this.Tema = Tema;
            this.DataIncricaoIninio= DataInscricao;
            this.DataIncricaoFim = DataInscricaoFim;
            this.DataComecoInicio= DataInicio;
            this.DataComecoFim = DataFim;

        }
        public int Id { get; set; }
        public Tema Tema { get; set; }
        public string DataIncricaoIninio { get; set; }
        public string DataIncricaoFim { get; set; }
        public string DataComecoInicio { get; set; }
        public string DataComecoFim { get; set; }
        public List<Stand>? Stands { get; set; }
        public override string ToString() { return this.Id.ToString(); }


    }
}
