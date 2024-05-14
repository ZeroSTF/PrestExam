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
    public class PrestationService : Service<Prestation>, IPrestationService
    {
        public PrestationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Prestation> getPrestationsClient(Client client)
        {
            IList<Prestation> prestations = new List<Prestation>();
            foreach (Prestation prestation in this.GetAll())
            {
                if (prestation.Client.Equals(client))
                {
                    prestations.Add(prestation);
                }
            }
            return prestations;

        }

        public IDictionary<string, IList<Prestation>> getPrestationsParClient(Client client)
        {
            IDictionary<string, IList<Prestation>> prestationsParClient = new Dictionary<string, IList<Prestation>>();
            foreach (Prestation prestation in this.getPrestationsClient(client))
            {
                string intitule = prestation.Prestataire.Specialite.Intitule.ToString();
                if (prestationsParClient.ContainsKey(intitule))
                {
                    prestationsParClient[intitule].Add(prestation);
                }
                else
                {
                    IList<Prestation> prestations = new List<Prestation>();
                    prestations.Add(prestation);
                    prestationsParClient.Add(intitule, prestations);
                }
            }
            return prestationsParClient;
        }
    }
}
