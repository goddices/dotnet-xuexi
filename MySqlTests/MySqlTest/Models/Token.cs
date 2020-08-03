using System;
using System.Collections.Generic;

namespace MySqlTest.Models
{
    public partial class Token
    {
        public Guid Id { get; set; }
        public string TokenType { get; set; }
        public string Account { get; set; }
        public string Purpose { get; set; }
        public string LastToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
