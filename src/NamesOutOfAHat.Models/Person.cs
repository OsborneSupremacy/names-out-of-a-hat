using System;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Person
    {
        [Required]
        public Guid Id { get; init; } = default!;

        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; } = default!;

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; init; } = default!;
    }
}
