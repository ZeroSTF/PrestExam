using ExamenBI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenBI.Data.Configurations
{
    public class TropheeConfigurations : IEntityTypeConfiguration<Trophee>

    {
        public void Configure(EntityTypeBuilder<Trophee> builder)
        {
            builder.HasOne(trophee => trophee.Equipe)
                .WithMany(equipe => equipe.Trophees)
               // .HasForeignKey("EquipeFK")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
