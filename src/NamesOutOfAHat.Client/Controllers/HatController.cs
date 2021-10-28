using Microsoft.AspNetCore.Mvc;
using NamesOutOfAHat.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
                    return new BadRequestObjectResult(new ValidationResult("One person makes for a lonely gift exchange. At at least two more people."));
                case 2:
                    return new BadRequestObjectResult(new ValidationResult("If your gift exchange has two people, they're going to get each other's name. No reason to pick names out of a hat! Add at least one more person."));
            }

            // validate emails
            var emails = people
                .Select(x => x.Email.Trim().ToLowerInvariant())
                .ToHashSet();

            foreach(var email in emails)
                if(people
                    .Where(x => x.Email.Trim().ToLowerInvariant().Equals(email))
                    .Count() > 1) 
                    return new BadRequestObjectResult(new ValidationResult($"The email address, {email}, is associated with more than one person in your gift exchange. If multiple names are sent to that address, that's going to cause problems. Everyone needs their own address."));

            // validate exclusion lists

            return new OkResult();
        }
    }
}
