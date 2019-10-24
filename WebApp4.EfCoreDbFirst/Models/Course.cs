using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Models
{
    public partial class Course
    {
        public Course()
        {
            Store = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Teacherid { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
