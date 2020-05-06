using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Workflowrobots
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public Guid WorkflowId { get; set; }
        public Guid RobotId { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual Workflows Workflow { get; set; }
    }
}
