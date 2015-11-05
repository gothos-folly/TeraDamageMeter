using System;
using System.Runtime.Serialization;

namespace NetworkSniffer
{
    [Serializable]
    public class NetworkSniffingException : Exception
    {
        public NetworkSniffingException()
        {
        }

        public NetworkSniffingException(string message) : base(message)
        {
        }

        public NetworkSniffingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NetworkSniffingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
