using ExamenBI.Domain.Entities;
using ProdStore.Data.Infrastructures;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenBI.Service
{
    public class ServiceTrophee : Service<Trophee>, IServiceTrophee
    {
        public ServiceTrophee(IUnitOfWork utk) : base(utk)
        {
        }

        //service4

        public DateTime DatePremierChampionnat(Equipe e)
        {
            return
            GetMany(t => t.TypeTrophee == "Championnat" && t.EquipeFK == e.EquipeId).OrderBy(t => t.DateTrophee)
                .Select(t => t.DateTrophee).First();
        }
    }
}
