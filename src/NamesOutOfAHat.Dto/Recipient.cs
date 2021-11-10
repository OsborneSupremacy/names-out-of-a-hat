using NamesOutOfAHat.Models;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Dto
{
    public record Recipient
    {
        [Required]
        public Person Person { get; init; } = default!;

        [Required]
        public bool Eligible { get; init; }
    }
}
