namespace Fair_ex.wwwroot.Models
{
    public class Feira
    {
        public string Id { get; set; }
        public string tema { get; set; }
        public DateTime dataIncricaoIninio { get; set; }
        public DateTime dataIncricaoFim { get; set; }
        public DateTime dataComecoInicio { get; set; }
        public DateTime dataComecoFim { get; set; }
        public List<Stand>? Stands { get; set; }
    }
}
