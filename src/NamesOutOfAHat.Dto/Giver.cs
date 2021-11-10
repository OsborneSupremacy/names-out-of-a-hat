using NamesOutOfAHat.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Dto
{
    public record GiverDto
    {
        [Required]
        public Person Person { get; init; } = default!;

        [Required, MinLength(1)]
        public IList<Recipient> Recipients { get; init; } = default!;
    }
}
