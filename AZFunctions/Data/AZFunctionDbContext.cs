using AZFunctions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZFunctions.Data
{
    public class AZFunctionDbContext : DbContext
    {
        public AZFunctionDbContext(DbContextOptions<AZFunctionDbContext> dbContextOptions) :
            base(dbContextOptions)
        {

        }
        public DbSet<SalesRequest> SalesRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalesRequest>(entity =>
            {
                entity.HasKey(c => c.Id);
            });
        }
    }
}
