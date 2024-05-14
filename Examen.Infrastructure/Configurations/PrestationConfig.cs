using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class PrestationConfig : IEntityTypeConfiguration<Prestation>
    {
        public void Configure(EntityTypeBuilder<Prestation> builder)
        {
            builder.HasOne(e => e.Client)
                    .WithMany(e => e.Prestations)
                    .HasForeignKey(e => e.ClientFK);
            builder.HasOne(e => e.Prestataire)
                .WithMany(e => e.Prestations)
                .HasForeignKey(e => e.PrestataireFK);
            builder.HasKey(e => new
            {
                e.ClientFK,
                e.PrestataireFK,
                e.HeureDebut
            });
            builder.Property(e => e.HeureDebut)
                .IsRequired()
                .HasColumnName("HeureRDV");
        }
    }
}
