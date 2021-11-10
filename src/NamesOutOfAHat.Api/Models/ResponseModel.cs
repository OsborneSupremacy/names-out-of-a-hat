using System.Collections.Generic;

namespace NamesOutOfAHat.Api.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }

        public IList<string> Errors { get; set; } = default!;
    }
}
