using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Tenants
    {
        public Tenants()
        {
            Users = new HashSet<Users>();
        }

        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public string Name { get; set; }
        public int Edition { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
