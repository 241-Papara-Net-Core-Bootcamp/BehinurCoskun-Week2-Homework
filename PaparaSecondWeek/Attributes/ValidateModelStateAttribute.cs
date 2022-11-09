using System;

namespace PaparaSecondWeek.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ValidateModelStateAttribute : Attribute
    {
    }
}
