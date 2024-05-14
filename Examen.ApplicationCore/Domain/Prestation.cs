using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Prestation
    {
        public DateTime HeureDebut { get; set; }
        public int NbrHeures { get; set; }
        public virtual Client Client { get; set; }
        public virtual Prestataire Prestataire { get; set; }
        public int ClientFK { get; set; }
        public int PrestataireFK { get; set; }
    }
}
