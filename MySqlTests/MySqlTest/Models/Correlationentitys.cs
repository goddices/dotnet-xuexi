using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Correlationentitys
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public Guid AuditLogId { get; set; }

        public virtual Auditlogs AuditLog { get; set; }
    }
}
