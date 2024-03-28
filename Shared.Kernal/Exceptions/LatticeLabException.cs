using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kernal.Exceptions
{
    public abstract class LatticeLabException : Exception
    {
        protected LatticeLabException(string message) : base(message)
        {
        }

        protected LatticeLabException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected LatticeLabException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

     
    }
}
