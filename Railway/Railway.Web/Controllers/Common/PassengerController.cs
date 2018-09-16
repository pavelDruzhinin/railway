using AutoMapper;
using Railway.Services;
using Railway.Services.Dto;
using Railway.Web.Models;
using System.Web.Mvc;

namespace Railway.Web.Controllers
{
    public class PassengerController : Controller
    {
        private readonly PassengerService _passengerService;

        public PassengerController(PassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        [Route("railway/info")]
        public ActionResult Info(int? id)
        {
            if (!id.HasValue)
                return View();

            var passenger = _passengerService.GetPassengerById(id.Value);

            return View(Mapper.Map<PassengerModel>(passenger));
        }

        [HttpPost]
        [Route("railway/info")]
        public ActionResult Info(PassengerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = Mapper.Map<PassengerDto>(model);

            _passengerService.SavePassenger(dto);

            return RedirectToAction("Passengers");
        }

        [HttpGet]
        [Route("")]
        [Route("railway/passengers")]
        public ActionResult Passengers()
        {
            return View(new PassengersViewModel
            {
                Passengers = _passengerService.GetPassengers()
            });
        }
    }
}