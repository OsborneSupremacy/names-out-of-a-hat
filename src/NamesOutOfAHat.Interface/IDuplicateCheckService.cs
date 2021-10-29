using System;
using System.Collections.Generic;
using System.Text;

namespace NamesOutOfAHat.Interface
{
    public interface IDuplicateCheckService
    {
        public (bool duplicatesExist, IList<string> errorMessages) Execute(IList<IPerson> people);
    }
}

