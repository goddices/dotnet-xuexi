using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Resourcegroups
    {
        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public int RobotQty { get; set; }
        public int ProgressQty { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }
    }
}
