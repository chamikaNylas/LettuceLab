using Shared.Kernal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
   
    public class GenaricException : LatticeLabException
    {
        public GenaricException() : base("This is a genaric exception.")
        {
        }
    }

}
