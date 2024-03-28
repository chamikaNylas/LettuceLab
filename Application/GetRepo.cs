using Domain.Entities;
using Domain.ValueObjects;
using Persistence;

namespace Application
{
    public class GetRepo
    {
        public ApplicationDbContext _DbContext { get; set; }
        public GetRepo(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }




        public void GetData()
        {

            //var lattuce = new List<Lettuce> { new Lettuce("lattice roller")};
            //var growBed = new List<GrowBed> { new GrowBed(10, 5, 2, lattuce) };
            //var container=new List<Container> { new Container(100,50,4,growBed)};
            //var greenHouce = new GreenHouse(2, new Guid("4d3f4343-5ddb-4df8-aff0-8eec98b5b273"),"green palace", container);
            //_DbContext.GreenHouses.Add(greenHouce);
            //_DbContext.SaveChanges();

               

            var greenHouse = _DbContext.GreenHouses.FirstOrDefault();
             var course=_DbContext.Courses.FirstOrDefault();
     
               
            greenHouse.ChangeName("silant green");
            //greenHouse.AddContainer(100,50,10);

            // greenHouse.RemoveContainer(greenHouse.Containers.FirstOrDefault());
            _DbContext.SaveChanges();
            
            var data=_DbContext.GreenHouses.ToList();
           
        
        }
    }
}