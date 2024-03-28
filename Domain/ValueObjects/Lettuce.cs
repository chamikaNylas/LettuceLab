using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Lettuce
    {
        public string Type { get; private set; }

        public Lettuce(string type)
        {
           
            if(string.IsNullOrEmpty(type))
                throw new LettuceTypeNullOrEmptyException();
            Type = type;
        }
    }
}
