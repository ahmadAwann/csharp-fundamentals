namespace Assignment_2.Question4
{
    internal class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}