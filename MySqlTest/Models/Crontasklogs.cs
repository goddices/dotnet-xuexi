using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Crontasklogs
    {
        public Guid Id { get; set; }
        public Guid CronTaskId { get; set; }
        public string Message { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public Guid? OperatorUserId { get; set; }
        public string OperatorUserName { get; set; }
    }
}
