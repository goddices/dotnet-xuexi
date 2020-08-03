using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Packageversions = new HashSet<Packageversions>();
        }

        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public string Name { get; set; }
        public string UploadFile { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UploadTime { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterUserId { get; set; }

        public virtual ICollection<Packageversions> Packageversions { get; set; }
    }
}
