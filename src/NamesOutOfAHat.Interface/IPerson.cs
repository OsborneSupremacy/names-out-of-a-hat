using System;

namespace NamesOutOfAHat.Interface
{
    public interface IPerson
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }
    }
}
