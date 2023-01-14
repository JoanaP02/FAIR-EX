namespace Fair_ex.Models
{
    public class Feira
    {
        public int Id { get; set; }
        public Tema Tema { get; set; }
        public string DataIncricaoIninio { get; set; }
        public string DataIncricaoFim { get; set; }
        public string DataComecoInicio { get; set; }
        public string DataComecoFim { get; set; }
        public List<Stand>? Stands { get; set; }


    }
}
