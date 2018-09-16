using Railway.Domain;
using Railway.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Railway.Web.Models
{
    public class PassengerModel
    {
        public int Id { get; set; }
        [RegularExpression("[А-Яа-я]")]
        public string Name { get; set; }

        public PassengerType Type { get; set; }
        [PassengerBirthDay]
        public DateTime BirthDay { get; set; }

        public bool IsBirthDayYearCorrespondPassengerType()
        {
            var year = BirthDay.Year;
            switch (Type)
            {
                case PassengerType.Adult:
                    return year > 10;
                case PassengerType.Child:
                    return year <= 10 && year > 5;
                case PassengerType.Baby:
                    return year <= 5;
            }

            return false;
        }
    }

    public class PassengerBirthDayAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "atleastonetrue",
            };
            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var passenger = (PassengerModel)validationContext.ObjectInstance;

            if (!passenger.IsBirthDayYearCorrespondPassengerType())
            {
                return new ValidationResult("Указанная дата рождения не соответствует типу пассажира");
            }

            return ValidationResult.Success;
        }
    }

    public class PassengersViewModel
    {
        public List<PassengerDto> Passengers { get; set; }
    }
}