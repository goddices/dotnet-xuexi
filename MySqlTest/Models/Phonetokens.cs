using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Phonetokens
    {
        public string Id { get; set; }
        public string Purpose { get; set; }
        public string LatestToken { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
