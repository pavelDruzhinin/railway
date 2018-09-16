using Railway.Domain;
using System;

namespace Railway.Services.Dto
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PassengerType Type { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
