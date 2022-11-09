using PaparaSecondWeek.Models;
using System;
using System.Text;

namespace PaparaSecondWeek.Services
{
    public class OwnerServices : IOwnerServices
    {
        public string Add()
        {
            return "Owner Eklendi";
        }

        public bool Delete()
        {
            return true;
        }

        public string Get()
        {
            return "Ownerlar getirildi";
        }
        public string GetColorEnum()
        {
            var sringBuilder = new StringBuilder();
            foreach (var color in Enum.GetNames(typeof(ColorEnum)))
            {
                sringBuilder.Append(color + "|");
            } 
            return sringBuilder.ToString();
        }
    }
}
