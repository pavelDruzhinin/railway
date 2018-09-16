using Railway.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Railway.Services.Infrastructure.Enums
{
    public static class EnumExtensions
    {
        public static IEnumerable<BaseDto> GetItems<T>() where T : struct, IComparable, IConvertible, IFormattable
        {
            return from Enum en in Enum.GetValues(typeof(T))
                   let attr = GetAttribute<DescriptionAttribute>(en)
                   select new BaseDto
                   {
                       Id = Convert.ToInt32(en),
                       Name = attr.Description,
                   };
        }

        public static string GetDescription(this Enum value, bool isLower = false)
        {
            var attribute = GetAttribute<DescriptionAttribute>(value);

            if (attribute == null)
                return null;

            return isLower ? attribute.Description?.ToLower() : attribute.Description;
        }

        private static T GetAttribute<T>(this Enum value) where T : class
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var attribs = fieldInfo?.GetCustomAttributes(typeof(T), false) as T[];

            if (attribs == null || attribs.Length <= 0)
                return null;

            return attribs.FirstOrDefault();
        }

    }
}
