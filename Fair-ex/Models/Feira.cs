using System.ComponentModel.DataAnnotations.Schema;

namespace Fair_ex.Models
{
    public class Feira
    {
        public Feira() {
        }


        public Feira(int Id, Tema Tema, DateTime DataInscricao, DateTime DataInscricaoFim, DateTime DataInicio, DateTime DataFim)
        {
            this.Id = Id;
            this.Tema = Tema;
            this.DataIncricaoIninio= DataInscricao;
            this.DataIncricaoFim = DataInscricaoFim;
            this.DataComecoInicio= DataInicio;
            this.DataComecoFim = DataFim;

        }
        [Column("idfeira")]
        public int Id { get; set; }
        [Column("tema_tema")]
        public Tema Tema { get; set; }
        [Column("dataDeInicioInscricao")]
        public DateTime DataIncricaoIninio { get; set; }
        [Column("dataDeFimInscricao")]
        public DateTime DataIncricaoFim { get; set; }
        [Column("dataComeco")]
        public DateTime DataComecoInicio { get; set; }
        [Column("dataTermino")]
        public DateTime DataComecoFim { get; set; }
        public List<Stand>? Stands { get; set; }
        public override string ToString() { return $"Feira: {Id}, {Tema.Nome}, {DataIncricaoIninio}, {DataIncricaoFim}, {DataComecoInicio}, {DataComecoFim}"; }


    }
}
