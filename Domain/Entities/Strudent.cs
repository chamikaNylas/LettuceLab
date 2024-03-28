using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{  
    public class Student
        {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Student(string name)
        {
            Name = name;
            Courses = new List<Course>();
        }
    }
 }

