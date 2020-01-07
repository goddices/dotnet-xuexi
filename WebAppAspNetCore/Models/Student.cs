using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Models
{
    public partial class Student
    {
        public Student()
        {
            Store = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Studentno { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<Store> Store { get; set; }
    }
}
