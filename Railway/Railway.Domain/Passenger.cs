using System;

namespace Railway.Domain
{
    public class Passenger
    {
        public Passenger()
        {

        }

        public Passenger(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
            Type = GetPassengerTypeByBirthDayYear(birthday.Year);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; }
        public PassengerType Type { get; set; }
        public DateTime BirthDay { get; set; }

        private PassengerType GetPassengerTypeByBirthDayYear(int year)
        {
            if (year > 10)
                return PassengerType.Adult;

            if (year > 5 && year <= 10)
                return PassengerType.Child;

            if (year <= 5)
                return PassengerType.Baby;

            throw new ArgumentException();
        }

    }

    public enum PassengerType
    {
        Adult,
        Child,
        Baby
    }
}
