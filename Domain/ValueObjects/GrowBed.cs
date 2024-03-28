using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record GrowBed
    {
        public decimal Length { get; private set; }
        public decimal Width { get; private set; }
        public decimal Height { get; private set; }
        private List<Lettuce> _Lettuces=new();

        public IReadOnlyCollection<Lettuce> Lettuces  => _Lettuces.AsReadOnly();
      

        public GrowBed(decimal length,
                       decimal width,
                       decimal height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public GrowBed()
        {

        }
    }
}
