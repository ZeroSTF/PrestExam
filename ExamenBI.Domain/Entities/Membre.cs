using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamenBI.Domain.Entities
{
    public class Membre
    {
        [Key]
        public int Identifiant { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
      [Required(ErrorMessage ="champs obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        public string Prenom { get; set; }

        //prop de navi
        public virtual IList<Contrat> Contrats { get; set; }
    }
}
