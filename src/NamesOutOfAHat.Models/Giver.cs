using NamesOutOfAHat.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Giver : IGiver
    {
        [Required]
        public IPerson Person { get; init; } = default!;

        [Required, MinLength(1)]
        public IList<IRecipient> Recipients { get; init; } = default!;
    }
}
