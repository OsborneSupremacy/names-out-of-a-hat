using NamesOutOfAHat.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Models
{
    public record Person : IPerson
    {
        [Required]
        public Guid Id { get; set; } = default!;

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = default!;

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; } = default!;
    }
}
