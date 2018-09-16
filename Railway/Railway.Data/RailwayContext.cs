using Railway.Data.Mappings;
using Railway.Domain;
using System.Data.Entity;

namespace Railway.Data
{
    public class RailwayContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PassengerMap());
        }

    }
}
