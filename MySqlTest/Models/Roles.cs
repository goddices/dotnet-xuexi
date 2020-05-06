using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Roleassignments = new HashSet<Roleassignments>();
            Users = new HashSet<Users>();
        }

        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsBuiltInAdmin { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }

        public virtual ICollection<Roleassignments> Roleassignments { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
