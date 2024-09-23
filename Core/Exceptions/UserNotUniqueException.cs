namespace Core.Exceptions
{
    public class UserNotUniqueException : Exception
    {
        public UserNotUniqueException() : base("Пользователь не уникален.")
        {
        }
    }
}
