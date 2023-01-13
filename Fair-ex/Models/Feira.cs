namespace Fair_ex.wwwroot.Models
{
    public class Feira
    {
        public int Id { get; set; }
        public Tema tema { get; set; }
        public DateTime dataIncricaoIninio { get; set; }
        public DateTime dataIncricaoFim { get; set; }
        public DateTime dataComecoInicio { get; set; }
        public DateTime dataComecoFim { get; set; }
        public List<Stand>? Stands { get; set; }
    }
}
