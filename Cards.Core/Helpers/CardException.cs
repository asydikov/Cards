using System;

namespace Cards.Core.Helpers
{
    public class CardException : Exception
    {
        public string ErrorCode { get; }

        public CardException() { }

        public CardException(string errorCode)
            : this(errorCode, null, null, null) { }

        public CardException(string message, params object[] args)
            : this(null, null, message, args) { }

        public CardException(string errorCode, string message, params object[] args)
            : this(errorCode, null, message, args) { }

        public CardException(Exception innerException, string message, params object[] args)
            : this(string.Empty, innerException, message, args) { }

        public CardException(string errorCode, Exception innerException, string message, params object[] args)
          : base(string.Format(message, args), innerException)
        {
            ErrorCode = errorCode;
        }
    }
}