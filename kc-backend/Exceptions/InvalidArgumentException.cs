namespace kc_backend.Exceptions
{
    [Serializable]
    public class InvalidArgumentException : BadRequestException
    {
        public InvalidArgumentException() { }
        public InvalidArgumentException(string message) : base(message) { }
        public InvalidArgumentException(string message, Exception inner) : base(message, inner) { }
    }
}
