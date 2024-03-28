using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Container
    {
        public decimal Length { get; private set; }
        public decimal Width { get; private set; }
        public decimal Height { get; private set; }
        private List<GrowBed> _GrowBeds=new();
        
        public IReadOnlyCollection<GrowBed> GrowBeds=> _GrowBeds.AsReadOnly();

        public Container(decimal length,
                          decimal width,
                          decimal height)
        {
            Length = length;
            Width = width;
            Height = height;       
        }

        private Container()
        { 
        }

    }
}
