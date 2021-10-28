using System;
using System.ComponentModel.DataAnnotations;

namespace NamesOutOfAHat.Client.Models
{
    public class Person
    {
        [Required]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
