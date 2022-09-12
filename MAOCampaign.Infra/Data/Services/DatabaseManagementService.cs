using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;
using MEOCampaign.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MEOCampaign.Infra.Data.Services
{
    /// <summary>
    /// Database Management Service
    /// </summary>
    public static class DatabaseManagementService
    {
        /// <summary>
        /// Get Instance of my Application Context to Migration Initialization
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void MigrationInitialization(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        /// <summary>
        /// Populate the database only in cases where there is no citizen data.
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(AppDbContext context)
        {
            if (!context.Citizens.Any())
            {
                Console.WriteLine("--> Seeding citizen data.");

                context.Citizens.AddRange(
                    new Citizen 
                    {
                        Name = "Citizen 01",
                        DateOfBirth = DateTime.Now,
                        Email = "citizen1@gmail.com",
                        PhoneNumber = "+351 918 554 887"
                    },
                    new Citizen
                    {
                        Name = "Citizen 02",
                        DateOfBirth = DateTime.Now,
                        Email = "citizen2@gmail.com",
                        PhoneNumber = "+351 918 554 887"
                    },
                    new Citizen
                    {
                        Name = "Citizen 03",
                        DateOfBirth = DateTime.Now,
                        Email = "citizen3@gmail.com",
                        PhoneNumber = "+351 918 554 887"
                    });

                context.SaveChanges();

                var citizen = context.Set<Citizen>().FirstOrDefault(c => c.Name == "Citizen 01");

                if(citizen != null)
                {
                    context.CitizenAddresses.AddRange(
                    new CitizenAddress
                    {
                        CitizenAddressId = citizen.CitizenId,
                        Street = "New Street, 10",
                        City = "Lisbon",
                        PostalCode = 123456
                    });

                    context.SaveChanges();
                }                
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }
        }
    }
}
