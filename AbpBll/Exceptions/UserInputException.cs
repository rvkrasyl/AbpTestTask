using System.Runtime.Serialization;

namespace AbpBll.Exceptions
{
    [Serializable]
    public class UserInputException : Exception
    {
        public UserInputException()
            : base()
        {
        }

        public UserInputException(string message)
            : base(message)
        {
        }

        public UserInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UserInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
