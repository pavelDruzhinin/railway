using AutoMapper;
using AutoMapper.QueryableExtensions;
using Railway.Data;
using Railway.Domain;
using Railway.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Railway.Services
{
    public class PassengerService
    {
        private readonly RailwayContext _railwayContext;

        public PassengerService(RailwayContext railwayContext)
        {
            _railwayContext = railwayContext;
        }

        public PassengerDto GetPassengerById(int id)
        {
            var passenger = _railwayContext.Passengers.FirstOrDefault(x => x.Id == id);

            if (passenger == null)
                throw new Exception("Не удалось найти указанного пассажира");

            return Mapper.Map<PassengerDto>(passenger);
        }

        public void SavePassenger(PassengerDto dto)
        {
            var passenger = _railwayContext.Passengers.FirstOrDefault(x => x.Id == dto.Id);

            if (passenger != null)
            {
                Mapper.Map(dto, passenger);
            }
            else
            {
                passenger = Mapper.Map<Passenger>(dto);
                _railwayContext.Passengers.Add(passenger);
            }

            _railwayContext.SaveChanges();
        }

        public List<PassengerDto> GetPassengers()
        {
            return _railwayContext.Passengers.ProjectTo<PassengerDto>().ToList();
        }
    }
}
