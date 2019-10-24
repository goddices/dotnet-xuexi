using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public int? Studentid { get; set; }
        public int? Courseid { get; set; }
        public decimal? Score { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
