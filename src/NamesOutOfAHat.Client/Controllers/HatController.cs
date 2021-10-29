using Microsoft.AspNetCore.Mvc;
using NamesOutOfAHat.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NamesOutOfAHat.Service;
using NamesOutOfAHat.Interface;
using NamesOutOfAHat.Models;

namespace NamesOutOfAHat.Client.Controllers
{
    public class HatController : Controller
    {
        private readonly ValidationService _validationService;

        public HatController(ValidationService validationService)
        {
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        [HttpPost]
        [Route("api/hat/validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] IList<Person> people)
        {
            var response = new ResponseModel();

            // TODO: Find a better way to do this.
            var people2 = new List<IPerson>();
            people2.AddRange(people);

            var (isValid, errors) = _validationService.Validate(people2);

            response.Errors = errors;
            response.Success = isValid;

            if (!isValid)
                return new BadRequestObjectResult(response);

            return new OkObjectResult(response);
        }
    }
}
