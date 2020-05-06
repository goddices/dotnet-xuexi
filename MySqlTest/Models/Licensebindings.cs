using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Licensebindings
    {
        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public string Code { get; set; }
        public string MachineName { get; set; }
        public byte Type { get; set; }
        public byte Status { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatorUser { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }
    }
}
