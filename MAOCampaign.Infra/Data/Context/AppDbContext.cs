using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MEOCampaign.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<CitizenAddress> CitizenAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizen>()
            .HasOne<CitizenAddress>(s => s.CitizenAddress)
            .WithOne(ad => ad.Citizen)
            .HasForeignKey<CitizenAddress>(ad => ad.CitizenAddressId);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //Records each "Mapping" at once
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}
