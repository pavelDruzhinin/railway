using Railway.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Mappings
{
    public class PassengerMap : EntityTypeConfiguration<Passenger>
    {
        public PassengerMap()
        {
            HasKey(x => x.Id);
        }
    }
}
