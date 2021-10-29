using NamesOutOfAHat.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NamesOutOfAHat.Service
{
    public abstract class DuplicateCheckService
    {
        protected IList<string> ErrorMessages { get; set; }

        protected DuplicateCheckService()
        {
            ErrorMessages = new List<string>();
        }

        protected void AddErrors<T>(IList<T> duplicateValues, string messageTemplate, Func<T, string> valueFormatter) =>
            ErrorMessages.ToList().AddRange(from value in duplicateValues
                                   select messageTemplate.Replace("{value}", valueFormatter(value)));

        protected static (bool, IList<T> duplicateValues) DuplicatesExist<T>(
            IList<IPerson> people,
            Func<IList<IPerson>, IEnumerable<T>> selector,
            Func<IPerson, T, bool> equals
        )
        {
            var duplicateValues = new List<T>();
            var values = selector(people).ToHashSet();

            foreach (var value in values)
                if (people
                    .Where(x => equals(x, value))
                    .Count() > 1)
                    duplicateValues.Add(value);

            return (duplicateValues.Any(), duplicateValues);
        }
    }

    public class NameDuplicateCheckService : DuplicateCheckService, IDuplicateCheckService
    {
        protected static Func<IList<IPerson>, IEnumerable<string>> _nameSelector = (IList<IPerson> people) =>
            people.Select(x => x.Name.Trim());

        protected static Func<IPerson, string, bool> _nameEquals = (IPerson person, string value) =>
            person.Name.Equals(value, StringComparison.OrdinalIgnoreCase);

        public (bool duplicatesExist, IList<string> errorMessages) Execute(IList<IPerson> people)
        {
            var (duplicatesExist, duplicateValues) = DuplicatesExist(people, _nameSelector, _nameEquals);
            if (!duplicatesExist) return (false, ErrorMessages);

            AddErrors(duplicateValues,
    "The name, `{value}` is associated with more than one person in your gift exchange. That could cause confusion for the participants. Please differentiate between the people named `{value}` (middle/last initial, city, etc.)",
                (string value) => { return value; }
            );

            return (true, ErrorMessages);
        }
    }

    public class EmailDuplicateCheckService : DuplicateCheckService, IDuplicateCheckService
    {
        protected static Func<IList<IPerson>, IEnumerable<string>> _emailSelector = (IList<IPerson> people) =>
            people.Select(x => x.Email.Trim());

        protected static Func<IPerson, string, bool> _emailEquals = (IPerson person, string value) =>
            person.Email.Equals(value, StringComparison.OrdinalIgnoreCase);

        public (bool duplicatesExist, IList<string> errorMessages) Execute(IList<IPerson> people)
        {
            var (duplicatesExist, duplicateValues) = DuplicatesExist(people, _emailSelector, _emailEquals);
            if (!duplicatesExist) return (false, ErrorMessages);

            AddErrors(duplicateValues,
    "The email address, `{email}`, is associated with more than one person in your gift exchange. If multiple names are sent to that address, that's going to cause problems. Everyone needs their own address.",
                (string value) => { return value; }
            );

            return (true, ErrorMessages);
        }
    }

    /// <summary>
    /// IDs are assigned on the frontend. We want to verify that no ID is re-used. This would only
    /// happen if there was a bug on the frontend. Probably not likely, but could yield bad consequences
    /// (e.g. a person being assigned to themself)
    /// </summary>
    public class IdDuplicateCheckService : DuplicateCheckService, IDuplicateCheckService
    {
        protected static Func<IList<IPerson>, IEnumerable<Guid>> _idSelector = (IList<IPerson> people) =>
            people.Select(x => x.Id);

        protected static Func<IPerson, Guid, bool> _idEquals = (IPerson person, Guid value) =>
            person.Name.Equals(value);

        public (bool duplicatesExist, IList<string> errorMessages) Execute(IList<IPerson> people)
        {
            var (duplicatesExist, duplicateValues) = DuplicatesExist(people, _idSelector, _idEquals);
            if (!duplicatesExist) return (false, ErrorMessages);

            AddErrors(duplicateValues,
    "We apologize but there in an internal issue with this application.",
                (Guid value) => { return value.ToString("N"); }
            );

            return (true, ErrorMessages);
        }
    }
}
