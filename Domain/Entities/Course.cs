using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<Student> Students { get; set; }

        public Course(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void ChangeName( string name)
        { 
            Name=name;
        }
    }
}