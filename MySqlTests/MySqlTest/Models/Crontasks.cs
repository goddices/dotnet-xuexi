using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Crontasks
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public string Name { get; set; }
        public string CronExpression { get; set; }
        public string WorkflowName { get; set; }
        public Guid WorkflowId { get; set; }
        public DateTime NextScheduleTime { get; set; }
        public DateTime? AllowCronTime { get; set; }
        public DateTime DisabledTime { get; set; }
        public bool Enabled { get; set; }
        public DateTime? SetDisabledTime { get; set; }
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
        public int CronHelperTag { get; set; }
        public string UserTimeZoneInfoId { get; set; }
    }
}
