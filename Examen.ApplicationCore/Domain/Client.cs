using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public virtual IList<Prestation> Prestations { get; set; }
        public virtual Coordonnees Coordonnees { get; set; }
    }
}