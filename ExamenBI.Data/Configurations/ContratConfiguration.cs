

using ExamenBI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data.Configurations
{
    public class ContratConfiguration : IEntityTypeConfiguration<Contrat>
    {
        public void Configure(EntityTypeBuilder<Contrat> builder)
        {
            builder.HasKey(f => new
            {
                f.EquipeFK,
                f.MembreFk,
                f.DateContrat
            });


          
        }
    }
}
