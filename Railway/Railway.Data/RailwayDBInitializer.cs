using Railway.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Railway.Data
{
    public class RailwayDBInitializer : CreateDatabaseIfNotExists<RailwayContext>
    {
        protected override void Seed(RailwayContext context)
        {
            base.Seed(context);

            var passengers = new List<Passenger>
            {
                new Passenger("Иванов Иван Иванович", new DateTime(1975, 1, 12)),
                new Passenger("Петров Иван Иванович", new DateTime(2015, 12, 12)),
                new Passenger("Сидоров Иван Иванович", new DateTime(2012, 1, 15)),
            };

            context.Passengers.AddRange(passengers);
            context.SaveChanges();
        }
    }
}
