using Shared.Kernal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class LettuceTypeNullOrEmptyException : LatticeLabException
    {
        public LettuceTypeNullOrEmptyException() : base("Lettuce type cant be null or empty.")
        {
        }
    }
}
