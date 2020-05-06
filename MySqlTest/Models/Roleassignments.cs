using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Roleassignments
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public byte ScopeType { get; set; }
        public Guid? ScopeId { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
