﻿using Examen.ApplicationCore.Domain;
using Examen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface ISpecialiteService : IService<Specialite>
    {
        public double getMoyenneTarifHoraire(string code);
    }
}
