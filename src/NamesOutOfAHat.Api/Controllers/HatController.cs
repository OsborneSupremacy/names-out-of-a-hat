using Microsoft.AspNetCore.Mvc;
using NamesOutOfAHat.Api.Models;
using System.Threading.Tasks;
using System;
using NamesOutOfAHat.Service;
using System.Linq;
using NamesOutOfAHat.Models;

namespace NamesOutOfAHat.Api.Controllers
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
        public async Task<IActionResult> ValidateAsync([FromBody] Hat hat)
        {
            var response = new ResponseModel();

            var givers = hat.Givers.ToList();

            (response.Success, response.Errors) = _validationService
                .Validate(givers);

            if (!response.Success)
                return new BadRequestObjectResult(response);

            return new OkObjectResult(response);
        }
    }
}
