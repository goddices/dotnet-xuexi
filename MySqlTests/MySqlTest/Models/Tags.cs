using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Tags
    {
        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
    }
}
