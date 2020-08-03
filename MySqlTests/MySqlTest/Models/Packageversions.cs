using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Packageversions
    {
        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid PackageId { get; set; }
        public string Version { get; set; }
        public string FileName { get; set; }
        public bool IsUse { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }

        public virtual Users CreatorUser { get; set; }
        public virtual Packages Package { get; set; }
    }
}
