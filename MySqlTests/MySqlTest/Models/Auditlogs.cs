using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Auditlogs
    {
        public Auditlogs()
        {
            Correlationentitys = new HashSet<Correlationentitys>();
        }

        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public string TenantName { get; set; }
        public Guid? GroupId { get; set; }
        public string ApplicationName { get; set; }
        public string EntityType { get; set; }
        public string Description { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int ExecutionDuration { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public string BrowserInfo { get; set; }
        public string Url { get; set; }
        public string MacAddress { get; set; }
        public string HttpMethod { get; set; }
        public string Parameters { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }

        public virtual ICollection<Correlationentitys> Correlationentitys { get; set; }
    }
}
