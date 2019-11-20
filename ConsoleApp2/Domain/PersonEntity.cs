using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2.Domain
{
    class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetEntity Pet { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public IEnumerable<AddressValue> Address { get; set; }
    }

    class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
    }

    class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public IEnumerable<AddressValue> Address { get; set; }
        public string PetName { get; set; }
        public override string ToString()
        {
            return $"id={Id},name={Name},pn={PhoneNumbers.First()},address={Address.First()},pet={PetName}";
        }

    }
}
