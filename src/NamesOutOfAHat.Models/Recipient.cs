using System;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Recipient
    {
        [Required]
        public Guid Id { get; init; } = default!;

        [Required]
        public Person Person { get; init; } = default!;

        [Required]
        public bool Eligible { get; init; }
    }
}
