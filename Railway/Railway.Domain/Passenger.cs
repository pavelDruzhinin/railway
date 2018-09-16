using System;
using System.ComponentModel;

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
            BirthDay = birthday;
            Type = GetPassengerTypeByBirthDayYear(birthday.Year);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public PassengerType Type { get; set; }
        public DateTime BirthDay { get; set; }

        private PassengerType GetPassengerTypeByBirthDayYear(int year)
        {
            var age = DateTime.Now.Year - year;

            if (age < 0)
                throw new ArgumentException();

            if (age <= 5)
                return PassengerType.Baby;

            if (age > 5 && age <= 10)
                return PassengerType.Child;
            
            return PassengerType.Adult;
        }

    }

    public enum PassengerType
    {
        [Description("Не задан")]
        NotSet,
        [Description("Взрослый")]
        Adult,
        [Description("Ребенок")]
        Child,
        [Description("Младенец")]
        Baby
    }
}
