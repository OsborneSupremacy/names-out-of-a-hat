using System.Collections.Generic;

namespace NamesOutOfAHat.Interface
{
    public interface IGiver
    {
        public IPerson Person { get; }

        public IList<IRecipient> Recipients { get; }
    }
}
