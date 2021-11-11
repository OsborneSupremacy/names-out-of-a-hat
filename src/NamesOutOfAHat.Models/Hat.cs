using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Hat
    {
        [Required, MinLength(1)]
        public IList<Giver> Givers { get; init; } = default!;
    }
}
