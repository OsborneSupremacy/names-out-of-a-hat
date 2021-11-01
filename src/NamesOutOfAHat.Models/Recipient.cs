using NamesOutOfAHat.Interface;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Recipient : IRecipient
    {
        [Required]
        public IPerson Person { get; init; } = default!;

        [Required]
        public bool Eligible { get; init; }
    }
}
