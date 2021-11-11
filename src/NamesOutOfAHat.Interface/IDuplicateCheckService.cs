using NamesOutOfAHat.Models;
using System.Collections.Generic;

namespace NamesOutOfAHat.Interface
{
    public interface IDuplicateCheckService
    {
        public (bool duplicatesExist, IList<string> errorMessages) Execute(IList<Person> people);
    }
}

