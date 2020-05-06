using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Jobinstances
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid RobotId { get; set; }
        public Guid WorkflowId { get; set; }
        public int JobStatus { get; set; }
        public string Name { get; set; }
        public int CreatedOrder { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ExecutingDateTime { get; set; }
        public DateTime? DoneDateTime { get; set; }
        public Guid PackageVersionId { get; set; }
        public string UserName { get; set; }
        public string RobotName { get; set; }
        public string PackageName { get; set; }
        public string PackageVersion { get; set; }
        public int Duration { get; set; }
        public int Retry { get; set; }
        public int RetryCount { get; set; }
        public string Variables { get; set; }
    }
}
