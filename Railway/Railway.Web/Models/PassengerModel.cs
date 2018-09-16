using Railway.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Railway.Web.Models
{
    public class PassengerModel
    {
        public int? Id { get; set; }

        [Display(Name = "Имя пассажира")]
        [RegularExpression("[А-Яа-я ]+", ErrorMessage = "Имя должно состоять только из русских букв")]
        [Required(ErrorMessage = "Является обязательным")]
        public string Name { get; set; }

        [Display(Name = "Тип пассажира")]
        public PassengerType Type { get; set; }

        [Display(Name = "Дата рождения пассажира")]
        [DataType(DataType.Date)]
        [PassengerBirthDay(ErrorMessage = "Дата рождения должна соответствовать типу пассажира")]
        [Required(ErrorMessage = "Является обязательным")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        public bool IsBirthDayYearCorrespondPassengerType()
        {
            if (Type == PassengerType.NotSet)
                return true;

            var age = DateTime.Now.Year - BirthDay.Year;
            switch (Type)
            {
                case PassengerType.Adult:
                    return age > 10;
                case PassengerType.Child:
                    return age <= 10 && age > 5;
                case PassengerType.Baby:
                    return age <= 5 && age >= 0;
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
}