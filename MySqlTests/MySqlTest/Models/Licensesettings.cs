using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Licensesettings
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public string Code { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatorUser { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
    }
}
