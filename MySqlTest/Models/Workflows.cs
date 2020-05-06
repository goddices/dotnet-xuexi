using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Workflows
    {
        public Workflows()
        {
            Workflowrobots = new HashSet<Workflowrobots>();
        }

        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public string Name { get; set; }
        public Guid PackageId { get; set; }
        public Guid PackageVersionId { get; set; }
        public string Description { get; set; }
        public DateTime? LastExecuteTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }
        public int RetryCount { get; set; }

        public virtual ICollection<Workflowrobots> Workflowrobots { get; set; }
    }
}
