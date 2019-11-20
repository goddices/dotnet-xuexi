using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Domain
{
    class AddressValue
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
        public override string ToString()
        {
            return $"country={Country},city={City},detail={Detail}";
        }
    }
}
