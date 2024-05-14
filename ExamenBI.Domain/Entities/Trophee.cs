using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamenBI.Domain.Entities
{
    public class Trophee
    {
        public int TropheeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public double Recompense { get; set; }
        public string TypeTrophee { get; set; }
        //2 eme methode
        public int EquipeFK { get; set; }

        [ForeignKey("EquipeFK")]
        public virtual Equipe Equipe { get; set; }

    }
}
