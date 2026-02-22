using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Yape.TransactionService.Infraestructure.Persistance
{
    public class TransactionDbContext(DbContextOptions<TransactionDbContext> options): DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //the the configuration of the entities through a folder ( configuration)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
            configurationBuilder.Properties<string>()
                .HaveMaxLength(100);
        }

    }
}
