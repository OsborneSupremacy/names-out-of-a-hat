using Microsoft.Extensions.DependencyInjection;
using NamesOutOfAHat.Interface;
using NamesOutOfAHat.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NamesOutOfAHat.Service
{
    [ServiceLifetime(ServiceLifetime.Scoped)]
    public class ValidationService
    {
        private const int _max = 30;

        private readonly IServiceProvider _serviceProvider;

        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public (bool isValid, IList<string> errors) Validate(IList<IPerson> people)
        {
            // basic component model validation
            foreach (var person in people)
            {
                var results = new List<ValidationResult>();
                var isValid = Validator
                    .TryValidateObject(person, new ValidationContext(person), results, true);
                if (!isValid)
                    return (false, results.Select(x => x.ErrorMessage).ToList());
            }

            // validate count
            (bool countsAreGood, IList<string> countErrors) = people.Count switch
            {
                0 => (false, errorToList("A gift exchange like this needs at least three people")),
                1 => (false, errorToList("One person makes for a lonely gift exchange. Add at least two more people.")),
                2 => (false, errorToList("If your gift exchange has exactly two people, they're going to get each other's name. No reason to pick names out of a hat! Add at least one more person.")),
                > _max => (false, errorToList($"{_max} people is the maximum. How did this get past frontend validation ? Are you trying to hack this app?")),
                _ => (true, null)
            };

            if (!countsAreGood)
                return (false, countErrors);

            var duplicateCheckServices = _serviceProvider.GetServices<IDuplicateCheckService>();

            foreach (var duplicateCheckService in duplicateCheckServices)
            {
                var (duplicatesExist, errorMessages) = duplicateCheckService.Execute(people);
                if (duplicatesExist)
                    return (false, errorMessages);
            }

            return (true, Enumerable.Empty<string>().ToList());

            IList<string> errorToList(string error) =>
                new List<string>() { error };
        }
    }
}
