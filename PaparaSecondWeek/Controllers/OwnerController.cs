using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaSecondWeek.Attributes;
using PaparaSecondWeek.Models;
using PaparaSecondWeek.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PaparaSecondWeek.Controllers
{
    //[ValidateModelState]  
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerServices _ownerServices;

        public OwnerController(IOwnerServices ownerServices)
        {
            _ownerServices = ownerServices;
        }

        [HttpPost("Create")]
        public IActionResult Post()
        {
            var result = _ownerServices.Add();
            return Ok(result);
        }
        [HttpGet("GetOwner")]
        public IActionResult Get()
        {
            var result = _ownerServices.Get();
            return Ok(result);
        }

        [HttpDelete("DeleteOwner")]
        public IActionResult Delete()
        {
            var result = _ownerServices.Delete();
            return Ok(result);
        }

        /// <summary>
        /// Reflection ile classların tüm propertilerini ekrana bastık
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOwnerProperties")]
        public IActionResult GetOwnerProperties()
        {
            Owner owner = new Owner();
            var result = new List<string>();
            var properties = owner.GetType().GetProperties().ToArray();
            foreach (var item in properties)
            {
                result.Add(item.Name);
            }
            return Ok(result);
        }
    }
}
