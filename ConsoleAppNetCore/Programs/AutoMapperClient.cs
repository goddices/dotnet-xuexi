using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppNetCore.Programs
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

    public class AutoMapperClient
    {
        public static void Run()
        {
            var cfg = new MapperConfiguration(e =>
            {
                e.CreateMap<PersonEntity, PersonDto>().IncludeMembers(s => s.Pet);
                e.CreateMap<PetEntity, PersonDto>().ForMember(p => p.PetName, m => m.MapFrom(s => s.Name));
            });

            Mapper mapper = new Mapper(cfg);
            var dto = mapper.Map<PersonDto>(new PersonEntity
            {
                Id = 1,
                Address = new AddressValue[] {
                    new AddressValue { City = "shanghai", Detail = "595#16#508" }
                },
                Name = "zhufeng",
                Pet = new PetEntity { Id = 1, Name = "小仙女", Kind = "cat" },
                PhoneNumbers = new String[] { "13918527915" }
            });

            Console.WriteLine(dto);
        }
    }
}
