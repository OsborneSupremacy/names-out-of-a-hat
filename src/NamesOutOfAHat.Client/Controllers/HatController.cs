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
            var allResults = new List<ValidationResult>();
            bool allValid = true;

            // basic component model validation
            foreach(var person in people)
            {
                var results = new List<ValidationResult>();
                var isValid = Validator
                    .TryValidateObject(person, new ValidationContext(person), results, true);
                if (!isValid) {
                    allValid = false;
                    allResults.AddRange(results);
                }
            }

            if (!allValid)
                return new BadRequestObjectResult(allResults.Select(x => x.ErrorMessage).ToList());

            // validate count
            switch (people.Count)
            {
                case 0:
                    return new BadRequestObjectResult(new ValidationResult("A gift exchange like this needs at least three people"));
                case 1:
                    return new BadRequestObjectResult(new ValidationResult("One person makes for a lonely gift exchange. Add at least two more people."));
                case 2:
                    return new BadRequestObjectResult(new ValidationResult("If your gift exchange has exactly two people, they're going to get each other's name. No reason to pick names out of a hat! Add at least one more person."));
                case > 100:
                    return new BadRequestObjectResult(new ValidationResult("100 people is the maximum. How did this get past frontend validation? Are you trying to hack this app?"));
            }

            // validate emails
            var emails = people
                .Select(x => x.Email.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach(var email in emails)
                if(people
                    .Where(x => x.Email.Trim().Equals(email, StringComparison.OrdinalIgnoreCase))
                    .Count() > 1) 
                    return new BadRequestObjectResult(new ValidationResult($"The email address, `{email}`, is associated with more than one person in your gift exchange. If multiple names are sent to that address, that's going to cause problems. Everyone needs their own address."));

            // validate names
            var names = people.Select(x => x.Name.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var name in names)
                if (people
                    .Where(x => x.Name.Trim().Equals(name, StringComparison.OrdinalIgnoreCase))
                    .Count() > 1)
                    return new BadRequestObjectResult(new ValidationResult($"The name, `{name}` is associated with more than one person in your gift exchange. That could cause confusion for the participants. Please differentiate between the people named `{name}` (middle/last initial, city, etc.)"));


            // validate exclusion lists

            return new OkResult();
        }
    }
}
