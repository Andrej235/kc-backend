namespace kc_backend.Exceptions
{
    [Serializable]
    public class InvalidLoginCredentialsException : BadRequestException
    {
        public InvalidLoginCredentialsException() { }
        public InvalidLoginCredentialsException(string message) : base(message) { }
        public InvalidLoginCredentialsException(string message, Exception inner) : base(message, inner) { }
    }
}
