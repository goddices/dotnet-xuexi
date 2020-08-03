using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Robots
    {
        public Guid Id { get; set; }
        public Guid RobotCode { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }
        public string ExtraProperties { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int RobotStatus { get; set; }
        public int RobotType { get; set; }
        public DateTime LastCommTime { get; set; }
        public DateTime CreationTime { get; set; }
        public string Version { get; set; }
        public string Tags { get; set; }
        public string DomainUsers { get; set; }
        public string MachineCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
