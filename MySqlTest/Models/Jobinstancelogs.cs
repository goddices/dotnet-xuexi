using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Jobinstancelogs
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public Guid JobId { get; set; }
        public DateTime LogDateTime { get; set; }
        public string Description { get; set; }
        public string ImageBlobUri { get; set; }
        public string Level { get; set; }
    }
}
