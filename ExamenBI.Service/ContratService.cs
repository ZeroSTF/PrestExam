using ExamenBI.Domain.Entities;
using ProdStore.Data.Infrastructures;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenBI.Service
{
    public class ContratService:Service<Contrat>,IContratService
    {

        public ContratService(IUnitOfWork utk) : base(utk)
        {
        }
        //service 2
        public IEnumerable<Joueur> JoueursTrophee(Trophee T)
        {
            var req = GetMany(c => c.EquipeFK == T.EquipeFK && (T.DateTrophee - c.DateContrat).Days < c.DureeMois * 30)
                .Select(c => c.Membre).OfType<Joueur>();

            return req;
        }

        //service3
        public IEnumerable<Entraineur> EntraineursEquipe(Equipe e)
        {
            return GetMany(c => c.EquipeFK == e.EquipeId).Select(c => c.Membre).OfType<Entraineur>();

        }

       

    }
}
