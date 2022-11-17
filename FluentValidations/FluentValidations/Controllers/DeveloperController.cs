using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidations.Filters;
using FluentValidations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FluentValidations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IValidator<Developer> _validator;

        public DeveloperController(IValidator<Developer> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult CreateDeveloper([FromBody] Developer developer)
        {
            return Ok();
        }
    }
}
