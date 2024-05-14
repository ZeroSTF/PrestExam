using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.Interfaces;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class PrestataireService : Service<Prestataire>, IPrestataireService
    {
        public PrestataireService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double getGainsMin()
        {
            double min = 0;
            Prestataire prestataire = this.GetAll().OrderBy(p => p.TarifHoraire).First();
            foreach (Prestation prestation in prestataire.Prestations)
            {
                if (prestation.HeureDebut.Year == DateTime.Now.Year) { 
                    min += prestation.NbrHeures * prestataire.TarifHoraire;
            }
            }

            return min;

        }

        public IList<Prestataire> getMeilleursPrestataires()
        {
            IList<Prestataire> prestataires = new List<Prestataire>();
            IList<Prestataire> prestatairesBricolage = new List<Prestataire>();
            foreach (Prestataire prestataire in this.GetAll())
            {
                if (prestataire.Specialite.Intitule.Equals(Intitule.Bricolage))
                {
                    prestatairesBricolage.Add(prestataire);
                }
            }
            prestatairesBricolage = prestatairesBricolage.OrderByDescending(p => p.Appreciation).ToList();
            prestataires.Add(prestatairesBricolage[0]);
            prestataires.Add(prestatairesBricolage[1]);
            return prestataires;
        }
    }
}
