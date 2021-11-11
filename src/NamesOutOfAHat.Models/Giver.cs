using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Giver
    {
        [Required]
        public Guid Id { get; init; } = default!;

        [Required]
        public Person Person { get; init; } = default!;

        [Required, MinLength(1)]
        public IList<Recipient> Recipients { get; init; } = default!;
    }
}
