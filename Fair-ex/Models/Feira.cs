using Fair_ex.Models;

namespace Fair_ex.wwwroot.Models
{
    public class Feira
    {
        public int Id { get; set; }
        public Tema Tema { get; set; }
        public DateTime DataIncricaoIninio { get; set; }
        public DateTime DataIncricaoFim { get; set; }
        public DateTime DataComecoInicio { get; set; }
        public DateTime DataComecoFim { get; set; }
        public List<Stand>? Stands { get; set; }
    }
}
