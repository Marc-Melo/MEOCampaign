using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MEOCampaign.Infra.Data.Mappings
{
    public class CitizenMapping : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.HasKey(p => p.CitizenId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.PhoneNumber)
               .IsRequired()
               .HasColumnType("varchar(11)");

            builder.Property(p => p.Email)
               .IsRequired()
               .HasColumnType("varchar(30)");

            // 1 : 1 => Citizen : CitizenAddress
            builder.HasOne(f => f.CitizenAddress)
                .WithOne(e => e.Citizen);
        }
    }
}
