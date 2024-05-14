using ExamenBI.Domain.Entities;
using ProdStore.Data.Infrastructures;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenBI.Service
{
    public class ServiceEquipe : Service<Equipe>, IServiceEquipe
    {
        public ServiceEquipe(IUnitOfWork utk) : base(utk)
        {
        }

        //service1
        public double Recompense(Equipe e)
        {
            var req = GetMany().Select(eq => eq.Trophees);
            double somme = 0;
            foreach (Trophee t in req)
            {
                somme = somme + t.Recompense;
            }
            return somme;
        }

        //service2
        
     
    }
}
