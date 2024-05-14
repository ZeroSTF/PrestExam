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
    public class SpecialiteService : Service<Specialite>, ISpecialiteService
    {
        public SpecialiteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double getMoyenneTarifHoraire(string code)
        {
            //retourner la moyenne de tarif horaire d'une specialite dont le code est passé en parametre
            double moyenne = 0;
            int count = 0;
            Specialite specialite = this.GetById(code);
                    foreach(Prestataire prestataire in specialite.Prestataires)
                    {
                        moyenne += prestataire.TarifHoraire;
                        count++;
                    }
            return moyenne / count;

        }


    }
}
