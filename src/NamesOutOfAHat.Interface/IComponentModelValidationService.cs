using System.Collections.Generic;

namespace NamesOutOfAHat.Interface
{
    public interface IComponentModelValidationService
    {
        public (bool isValid, IList<string> errors) Validate<T>(IList<T> items);
    }
}
