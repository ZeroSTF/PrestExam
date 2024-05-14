using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Specialite
    {
        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
        public Intitule Intitule { get; set; }
        public virtual IList<Prestataire> Prestataires { get; set; }
    }
    public enum Intitule
    { Bricolage, Jardinage, Menage }
}
