using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Uploadrecords
    {
        public Guid Id { get; set; }
        public string ExtraProperties { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string UploadUser { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public bool IsLastest { get; set; }
    }
}
