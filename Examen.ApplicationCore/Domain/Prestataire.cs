using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Prestataire
    {
        [Range(0, 5, ErrorMessage = "Appreciation doit etre entre 0 et 5")]
        public int Appreciation { get; set; }
        [Key]
        public int PrestataireId { get; set; }
        [StringLength(20)]
        public string PrestataireNom { get; set; }
        public string PrestatairePhoto { get; set; }
        public string PrestataireTel { get; set; }
        [DataType(DataType.Currency)]
        public double TarifHoraire { get; set; }
        public virtual IList<Prestation> Prestations { get; set; }
        public virtual Specialite Specialite { get; set; }
        [ForeignKey("Specialite")]
        public int SpecialiteFK { get; set; }
    }
}
