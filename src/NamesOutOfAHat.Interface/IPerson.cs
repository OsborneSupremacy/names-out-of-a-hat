using System;

namespace NamesOutOfAHat.Interface
{
    public interface IPerson
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
