using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GreenHouseManager
    {
        public Guid Id { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public string DoB { get; private set; }

    }
}
