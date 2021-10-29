using Microsoft.AspNetCore.Mvc;
using NamesOutOfAHat.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace NamesOutOfAHat.Client.Controllers
{
    public class HatController : Controller
    {
        [HttpPost]
        [Route("api/hat/validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] List<Person> people)
        {
            var response = new ResponseModel(); 

            // basic component model validation
            foreach(var person in people)
            {
                var results = new List<ValidationResult>();
                var isValid = Validator
                    .TryValidateObject(person, new ValidationContext(person), results, true);
                if (!isValid)
                    response.Errors.AddRange(results.Select(x => x.ErrorMessage).ToList());
            }

            if (response.AnyErrors())
                return new BadRequestObjectResult(response);

            // validate count
            switch (people.Count)
            {
                case 0:
                    response.AddError("A gift exchange like this needs at least three people");
                    break;
                case 1:
                    response.AddError("One person makes for a lonely gift exchange. Add at least two more people.");
                    break;
                case 2:
                    response.AddError("If your gift exchange has exactly two people, they're going to get each other's name. No reason to pick names out of a hat! Add at least one more person.");
                    break;
                case > 30:
                    response.AddError("100 people is the maximum. How did this get past frontend validation ? Are you trying to hack this app? ");
                    break;
            }

            if (response.AnyErrors())
                return new BadRequestObjectResult(response);

            // validate emails
            var emails = people
                .Select(x => x.Email.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var email in emails)
                if (people
                    .Where(x => x.Email.Trim().Equals(email, StringComparison.OrdinalIgnoreCase))
                    .Count() > 1)
                    response.AddError($"The email address, `{email}`, is associated with more than one person in your gift exchange. If multiple names are sent to that address, that's going to cause problems. Everyone needs their own address.");

            // validate names
            var names = people.Select(x => x.Name.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var name in names)
                if (people
                    .Where(x => x.Name.Trim().Equals(name, StringComparison.OrdinalIgnoreCase))
                    .Count() > 1)
                    response.AddError($"The name, `{name}` is associated with more than one person in your gift exchange. That could cause confusion for the participants. Please differentiate between the people named `{name}` (middle/last initial, city, etc.)");
            
            if (response.AnyErrors())
                return new BadRequestObjectResult(response);

            // validate exclusion lists

            response.Success = true;
            return new OkObjectResult(response);
        }
    }
}
