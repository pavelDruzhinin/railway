namespace Railway.Data.Migrations
{
    using Railway.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RailwayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RailwayContext context)
        {
            var passengers = new List<Passenger>
            {
                new Passenger("Иванов Иван Иванович", new DateTime(1975, 01, 12)),
                new Passenger("Петров Иван Иванович", new DateTime(2015, 12, 12)),
                new Passenger("Сидоров Иван Иванович", new DateTime(2012, 01, 15)),
            };

            context.Passengers.AddRange(passengers);
            context.SaveChanges();
        }
    }
}
