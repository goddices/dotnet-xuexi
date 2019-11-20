using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleApp2.Domain;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cfg = new MapperConfiguration(e =>
            {
                e.CreateMap<PersonEntity, PersonDto>().IncludeMembers(s => s.Pet);
                e.CreateMap<PetEntity, PersonDto>().ForMember(p => p.PetName, m => m.MapFrom(s => s.Name));
            }); 

            Mapper mapper = new Mapper(cfg);
            var dto = mapper.Map<PersonDto>(new PersonEntity
            {
                Id = 1,
                Address = new AddressValue[] { new AddressValue { City = "shanghai", Detail = "595" } },
                Name = "zhufeng",
                Pet = new PetEntity { Id = 1, Name = "miao", Kind = "cat" },
                PhoneNumbers = new String[] { "13918527915" }
            });

            Console.WriteLine(dto);
            Console.ReadLine();
        }


    }
}
