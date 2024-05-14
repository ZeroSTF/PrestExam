using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenBI.Domain.Entities
{
   public class Equipe
    {
        public int EquipeId { get; set; } //nomDelaClasseId : clé primaire
        public string AdresseLocal { get; set; }
        public string Logo { get; set; }
        public string NomEquipe { get; set; }

        public virtual IList<Contrat> Contrats { get; set; }
        public virtual IList<Trophee> Trophees { get; set; }
    }
}
