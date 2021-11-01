namespace NamesOutOfAHat.Interface
{
    public interface IRecipient
    {
        public IPerson Person { get; }

        public bool Eligible { get; }
    }
}