using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using NamesOutOfAHat.Utility;
using Microsoft.Extensions.DependencyInjection;
using NamesOutOfAHat.Interface;

namespace NamesOutOfAHat.Service
{
    [RegistrationTarget(typeof(IComponentModelValidationService))]
    [ServiceLifetime(ServiceLifetime.Scoped)]
    public class ComponentModelValidationService : IComponentModelValidationService
    {
        public (bool isValid, IList<string> errors) Validate<T>(IList<T> items)
        {
            // basic component model validation
            foreach (var item in items)
            {
                if (item == null) continue;

                var results = new List<ValidationResult>();
                var isValid = Validator
                    .TryValidateObject(item, new ValidationContext(item), results, true);
                if (!isValid)
                    return (false, results.Select(x => x.ErrorMessage ?? string.Empty).ToList());
            }

            return (true, Enumerable.Empty<string>().ToList());
        }

    }
}
