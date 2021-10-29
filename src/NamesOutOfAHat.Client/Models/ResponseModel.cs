using System.Collections.Generic;
using System.Linq;

namespace NamesOutOfAHat.Client.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Errors = new List<string>();
            Success = false;
        }

        public bool Success { get; set; }

        public bool AnyErrors() => Errors.Any();

        public List<string> Errors { get; set; }

        public void AddError(string error) => Errors.Add(error);
    }
}
