using Domain.ValueObjects;
using Shared.Kernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GreenHouse : AggregateRoot
    {
        public int No { get; private set; }
        public string Name { get; private set; }
        private List<Container> _Containers = new();
        private List<GreenHouseManager> _GreenHouseManagers = new();
        public IReadOnlyCollection<Container> Containers => _Containers.AsReadOnly();
        public IReadOnlyCollection<GreenHouseManager> GreenHouseManagers => _GreenHouseManagers.AsReadOnly();

        public GreenHouse(int No,
                          Guid id,
                          string name) : base(id)
        {
            id = id;
            this.No = No;
            Name = name;

        }

        private GreenHouse(Guid id) : base(id)
        {
        }

        public void AddGreenHouse()
        {

        }
        public void AddContainer(decimal length,
                          decimal width,
                          decimal height)
        {

            _Containers.Add(new Container(length, width, height));

        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public void RemoveContainer(Container container)
        {
            _Containers.Remove(container);
        }

      
        
    }
}
