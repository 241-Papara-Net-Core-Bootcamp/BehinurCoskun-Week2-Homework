using System;
using System.Text;

namespace PaparaSecondWeek.Extensions.EnumExtension
{
    public static class EnumExtensions
    {
        public static string GetColorEnums(this Enum value)
        {
            return value.ToString();
            //var stringBuilder = new StringBuilder();
            //foreach (string item in value.GetType().Name)
            //{

            //}
        }
    }
}
