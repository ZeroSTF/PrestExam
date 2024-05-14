using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamenBI.Domain.Entities
{
    public class Contrat
    {
        public DateTime DateContrat { get; set; }

        [Range(0,24)]
        public int DureeMois { get; set; }
        public double Salaire { get; set; }

        public int EquipeFK { get; set; }
        public int MembreFk { get; set; }

        //prop de navig
        [ForeignKey("EquipeFK")]
        public virtual Equipe Equipe { get; set; }
        [ForeignKey("MembreFk")]
        public virtual Membre Membre { get; set; }
    }
}
