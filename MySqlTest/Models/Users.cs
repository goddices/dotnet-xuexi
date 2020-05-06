using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Users
    {
        public Users()
        {
            Packageversions = new HashSet<Packageversions>();
            Roleassignments = new HashSet<Roleassignments>();
        }

        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? TenantId { get; set; }
        public string FullName { get; set; }
        public int UserStatus { get; set; }
        public Guid? RoleId { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Tenants Tenant { get; set; }
        public virtual ICollection<Packageversions> Packageversions { get; set; }
        public virtual ICollection<Roleassignments> Roleassignments { get; set; }
    }
}
